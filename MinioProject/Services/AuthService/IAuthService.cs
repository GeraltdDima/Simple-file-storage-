using Models;
using Models.Enums;

namespace Services
{
    public interface IAuthService
    {
        Task<AuthResultDto> RegisterAsync(RegisterDto registerDto);
        Task <LoginResultDto> LoginAsync(LoginDto loginDto);
        
        Task<AuthResultDto> CreateRoleAsync(Roles role);
    }
}