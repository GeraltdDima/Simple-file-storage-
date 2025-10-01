using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Models.Factories
{
    public class AccessTokenFactory : IAccessTokenFactory
    {
        private readonly IJwtSettingsFactory _jwtSettingsFactory;
        
        public AccessTokenFactory(IJwtSettingsFactory jwtSettingsFactory)
        {
            _jwtSettingsFactory = jwtSettingsFactory;
        }

        public async Task<AccessTokenDto> CreateAccessTokenAsync(IEnumerable<Claim> claims)
        {
            var jwtSettings = _jwtSettingsFactory.GetJwtSettings();
            var expiryTime = DateTime.UtcNow.AddMinutes(30);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: expiryTime,
                signingCredentials: creds
            );
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);
            
            return new AccessTokenDto(tokenString, expiryTime);
        }
    }
}