namespace Models
{
    public class CorsPolicySettingsDto
    {
        public CorsPolicySettingsDto(string policyName, string[] allowedOrigins)
        {
            PolicyName = policyName;
            AllowedOrigins = allowedOrigins;
        }
        
        public string PolicyName { get; set; }
        public string[] AllowedOrigins { get; set; }
    }
}