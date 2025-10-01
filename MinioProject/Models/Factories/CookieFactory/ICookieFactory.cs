namespace Models.Factories
{
    public interface ICookieFactory
    {
        void CreateCookie(string label, string value, DateTime expires);
    }
}