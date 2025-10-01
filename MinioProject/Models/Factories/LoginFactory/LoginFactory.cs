using Microsoft.AspNetCore.Identity;
using Models.Enums;
using Services;

namespace Models.Factories
{
    public class LoginFactory : ILoginFactory
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        
        private readonly IJwtService _jwtService;
        private readonly ICookieService _cookieService;
        
        private readonly IClaimsFactory _claimsFactory;
        
        public LoginFactory(SignInManager<User> signInManager, UserManager<User> userManager, IJwtService jwtService, IClaimsFactory claimsFactory, ICookieService cookieService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
            _claimsFactory = claimsFactory;
            _cookieService = cookieService;
        }

        public async Task<LoginResultDto> CreateLoginAsync(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                loginDto.Email,
                loginDto.Password,
                loginDto.RememberMe,
                true
            );

            if (!result.Succeeded)
                return new LoginResultDto(AuthResult.Failure);
            
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            
            if (user == null)
                return new LoginResultDto(AuthResult.UserNotFound);

            var claims = await _claimsFactory.GetClaimsAsync(user);
            
            var accessToken = await _jwtService.CreateAccessToken(claims);
            var refreshToken = _jwtService.CreateRefreshToken();
            
            user.RefreshToken = refreshToken.Token;
            user.RefreshTokenExpiryTime = refreshToken.ExpiryTime;
            
            await _userManager.UpdateAsync(user);
            
            _cookieService.CreateCookie("refreshToken", refreshToken.Token, refreshToken.ExpiryTime);
            
            return new LoginResultDto(AuthResult.Success, accessToken);
        }
    }
}