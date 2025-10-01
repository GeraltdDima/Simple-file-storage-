using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Factories;
using Services;

namespace Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RefreshTokenController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        
        private readonly ICookieService _cookieService;
        private readonly IJwtService _jwtService;
        
        private readonly IClaimsFactory _claimsFactory;
        
        public RefreshTokenController(ICookieService cookieService, IJwtService jwtService, IClaimsFactory claimsFactory, UserManager<User> userManager)
        {
            _cookieService = cookieService;
            _jwtService = jwtService;
            _claimsFactory = claimsFactory;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            
            if (refreshToken == null)
                return Unauthorized();
            
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);
            
            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow) return Unauthorized();

            var claims = await _claimsFactory.GetClaimsAsync(user);

            var newAccessToken = await _jwtService.CreateAccessToken(claims);
            var newRefreshToken = _jwtService.CreateRefreshToken();

            user.RefreshToken = newRefreshToken.Token;
            user.RefreshTokenExpiryTime = newRefreshToken.ExpiryTime;
            
            await _userManager.UpdateAsync(user);
            
            _cookieService.CreateCookie("refreshToken", newRefreshToken.Token, newRefreshToken.ExpiryTime);

            return Ok(newAccessToken);
        }
    }
}