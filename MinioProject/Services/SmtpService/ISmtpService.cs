namespace Services
{
    public interface ISmtpService
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}