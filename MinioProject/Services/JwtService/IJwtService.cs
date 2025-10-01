using System.Security.Claims;
using Models;

namespace Services
{
    public interface IJwtService
    {
        Task<AccessTokenDto> CreateAccessToken(IEnumerable<Claim> claims);
        RefreshTokenDto CreateRefreshToken();
    }
}