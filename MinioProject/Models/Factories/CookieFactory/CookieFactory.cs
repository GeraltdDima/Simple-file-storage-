namespace Models.Factories
{
    public class CookieFactory : ICookieFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICookieOptionsFactory _cookieOptionsFactory;
        
        public CookieFactory(IHttpContextAccessor httpContextAccessor, ICookieOptionsFactory cookieOptionsFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _cookieOptionsFactory = cookieOptionsFactory;
        }

        public void CreateCookie(string label, string value, DateTime expires)
        {
            var options = _cookieOptionsFactory.CreateCookieOptions(expires);
            
            _httpContextAccessor.HttpContext.Response.Cookies.Append(label, value, options);
        }
    }
}