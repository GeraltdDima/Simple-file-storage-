using System.Security.Claims;

namespace Models.Factories
{
    public interface IClaimsFactory
    {
        Task<IEnumerable<Claim>> GetClaimsAsync(User user);
    }
}