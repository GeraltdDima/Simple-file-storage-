using Microsoft.AspNetCore.Identity;
using Models.Enums;

namespace Models.Factories
{
    public class RoleFactory : IRoleFactory
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public RoleFactory(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<AuthResultDto> CreateRoleAsync(Roles role)
        {
            var roleString = role.ToString();
            
            var roleExists = await _roleManager.RoleExistsAsync(roleString);

            if (roleExists)
                return new AuthResultDto(AuthResult.Failure);

            var identityRole = new IdentityRole(roleString);
            var result = await _roleManager.CreateAsync(identityRole);
            
            if (result.Succeeded)
                return new AuthResultDto(AuthResult.Success);
            
            return new AuthResultDto(AuthResult.Failure, result.Errors);
        }
    }
}