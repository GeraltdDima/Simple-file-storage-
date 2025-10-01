using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Models
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;
        private SmtpSettingsDto _smtpSettings;
        
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpSettings = GetSmtpSettings();
        }
        
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var client = new SmtpClient(_smtpSettings.SmtpHost, _smtpSettings.SmtpPort))
            {
                client.Credentials = new NetworkCredential(_smtpSettings.SmtpUser, _smtpSettings.SmtpPass);
                client.EnableSsl = true;
                
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.FromEmail),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true,
                };
                
                mailMessage.To.Add(email);
                
                await client.SendMailAsync(mailMessage);
            }
        }

        private SmtpSettingsDto GetSmtpSettings()
        {
            return _configuration.GetSection("Smtp").Get<SmtpSettingsDto>();
        }
    }
}