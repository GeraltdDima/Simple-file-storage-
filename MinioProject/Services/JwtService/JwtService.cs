using Models;
using Models.Factories;
using System.Security.Claims;

namespace Services
{
    public class JwtService : IJwtService
    {
        private readonly IAccessTokenFactory _accessTokenFactory;
        private readonly IRefreshTokenFactory _refreshTokenFactory;
        
        public JwtService(IAccessTokenFactory accessTokenFactory, IRefreshTokenFactory refreshTokenFactory)
        {
            _accessTokenFactory = accessTokenFactory;
            _refreshTokenFactory = refreshTokenFactory;
        }
        
        public async Task<AccessTokenDto> CreateAccessToken(IEnumerable<Claim> claims) =>
            await _accessTokenFactory.CreateAccessTokenAsync(claims);
        
        public RefreshTokenDto CreateRefreshToken() =>
            _refreshTokenFactory.CreateRefreshToken();
    }
}