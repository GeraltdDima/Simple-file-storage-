namespace Models
{
    public class ErrorLoggingDto
    {
        public ErrorLoggingDto(string message, string type)
        {
            Message = message;
            Type = type;
        }

        public string Message { get; set; }
        public string Type { get; set; }
    }
}