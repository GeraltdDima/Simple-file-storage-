using Microsoft.AspNetCore.Identity;
using Models.Enums;
using Services;

namespace Models.Factories
{
    public class RegisterFactory : IRegisterFactory
    {
        private readonly UserManager<User> _userManager;
        private readonly ISmtpService _smtpService;
        private readonly IEmailConfirmFactory _emailConfirmFactory;
        
        public RegisterFactory(UserManager<User> userManager, ISmtpService smtpService, IEmailConfirmFactory emailConfirmFactory)
        {
            _userManager = userManager;
            _smtpService = smtpService;
            _emailConfirmFactory = emailConfirmFactory;
        }

        public async Task<AuthResultDto> RegisterAsync(RegisterDto registerDto)
        {
            if (registerDto == null)
                return new AuthResultDto(AuthResult.Failure);
            
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            
            if (existingUser != null)
                return new AuthResultDto(AuthResult.Failure);

            var newUser = new User()
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };
            
            var result = await _userManager.CreateAsync(newUser, registerDto.Password);
            
            if (!result.Succeeded)
                return new AuthResultDto(AuthResult.Failure, result.Errors);
            
            var emailConfirmDto = await _emailConfirmFactory.CreateEmailConfirmAsync(newUser);
            
            await _smtpService.SendEmailAsync(emailConfirmDto.Email, emailConfirmDto.Subject, emailConfirmDto.Message);
            
            return new AuthResultDto(AuthResult.Success);
        }
    }
}