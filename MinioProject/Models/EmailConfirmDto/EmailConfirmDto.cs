namespace Models
{
    public class EmailConfirmDto
    {
        public EmailConfirmDto(string email, string subject, string message)
        {
            Email = email;
            Subject = subject;
            Message = message;
        }
        
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; } 
    }
}