using Models.Enums;

namespace Models
{
    public class LoginResultDto
    {
        public LoginResultDto(AuthResult result, AccessTokenDto? accessToken = null)
        {
            Result = result;
            AccessToken = accessToken;
        }
        
        public AuthResult Result { get; set; }
        
        public AccessTokenDto? AccessToken { get; set; }
    }
}