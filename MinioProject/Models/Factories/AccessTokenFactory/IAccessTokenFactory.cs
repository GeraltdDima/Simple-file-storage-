using System.Security.Claims;

namespace Models.Factories
{
    public interface IAccessTokenFactory
    {
        Task<AccessTokenDto> CreateAccessTokenAsync(IEnumerable<Claim> claims);
    }
}