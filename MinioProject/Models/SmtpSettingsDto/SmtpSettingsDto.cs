namespace Models
{
    public class SmtpSettingsDto
    {
        public SmtpSettingsDto(string smtpHost, int smtpPort, string smtpUser, string smtpPass, string fromEmail)
        {
            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
            SmtpUser = smtpUser;
            SmtpPass = smtpPass;
            FromEmail = fromEmail;
        }

        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string FromEmail { get; set; }
    }
}