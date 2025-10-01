namespace Models
{
    public class CorsSettingsDto
    {
        public CorsSettingsDto(CorsPolicySettingsDto[] policies)
        {
            Policies = policies;
        }

        public CorsPolicySettingsDto[] Policies { get; set; }
    }
}