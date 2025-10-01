using Microsoft.AspNetCore.Identity.UI.Services;

namespace Services
{
    public class SmtpService : ISmtpService
    {
        private readonly IEmailSender _emailSender;
        
        public SmtpService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        
        public async Task SendEmailAsync(string email, string subject, string htmlMessage) =>
            await _emailSender.SendEmailAsync(email, subject, htmlMessage);
    }
}