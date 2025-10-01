using Models.Factories;

namespace Services
{
    public class CookieService : ICookieService
    {
        private readonly ICookieFactory _cookieFactory;
        
        public CookieService(ICookieFactory cookieFactory)
        {
            _cookieFactory = cookieFactory;
        }
        
        public void CreateCookie(string label, string value, DateTime expires) =>
            _cookieFactory.CreateCookie(label, value, expires);
    }
}