using Models.Factories;
using Models.Enums;
using Models;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IRegisterFactory _registerFactory;
        private readonly ILoginFactory _loginFactory;
        private readonly IRoleFactory _roleFactory;
        
        public AuthService(IRegisterFactory registerFactory, ILoginFactory loginFactory, IRoleFactory roleFactory)
        {
            _registerFactory = registerFactory;
            _loginFactory = loginFactory;
            _roleFactory = roleFactory;
        }

        public async Task<AuthResultDto> RegisterAsync(RegisterDto registerDto) =>
            await _registerFactory.RegisterAsync(registerDto);
        
        public async Task<LoginResultDto> LoginAsync(LoginDto loginDto) =>
            await _loginFactory.CreateLoginAsync(loginDto);
        
        public async Task<AuthResultDto> CreateRoleAsync(Roles role) =>
            await _roleFactory.CreateRoleAsync(role);
    }
}