using Models.Enums;

namespace Models.Factories
{
    public interface IRoleFactory
    {
        Task<AuthResultDto> CreateRoleAsync(Roles role);
    }
}