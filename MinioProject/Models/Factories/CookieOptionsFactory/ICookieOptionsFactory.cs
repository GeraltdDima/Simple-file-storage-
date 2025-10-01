using System.Security.Claims;

namespace Models.Factories
{
    public interface ICookieOptionsFactory
    {
        CookieOptions CreateCookieOptions(DateTime expires);
    }
}