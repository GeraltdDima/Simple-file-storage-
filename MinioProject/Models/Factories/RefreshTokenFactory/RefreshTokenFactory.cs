using System.Security.Cryptography;

namespace Models.Factories
{
    public class RefreshTokenFactory : IRefreshTokenFactory
    {
        public RefreshTokenDto CreateRefreshToken()
        {
            byte[] randomBytes = new byte[64];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(randomBytes);
                
                string token = Convert.ToBase64String(randomBytes);
                var expiryTime = DateTime.UtcNow.AddHours(4);
                
                return new RefreshTokenDto(token, expiryTime);
            }
        }
    }
}