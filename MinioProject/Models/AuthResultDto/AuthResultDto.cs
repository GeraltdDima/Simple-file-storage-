using Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class AuthResultDto
    {
        public AuthResultDto(AuthResult result, IEnumerable<IdentityError> errors = null)
        {
            Result = result;
            Errors = errors;
        }
        
        public AuthResult Result { get; set; }
        public IEnumerable<IdentityError>? Errors { get; set; }
    }
}