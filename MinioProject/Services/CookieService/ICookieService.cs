namespace Services
{
    public interface ICookieService
    {
        void CreateCookie(string label, string value, DateTime expires);
    }
}