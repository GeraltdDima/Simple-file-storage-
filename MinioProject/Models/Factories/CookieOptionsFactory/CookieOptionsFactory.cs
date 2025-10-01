namespace Models.Factories
{
    public class CookieOptionsFactory : ICookieOptionsFactory
    {
        public CookieOptions CreateCookieOptions(DateTime expires) =>
            new CookieOptions
            {
                HttpOnly = true,
                Expires = expires,
                SameSite = SameSiteMode.Strict,
                Secure = true
            };
    }
}