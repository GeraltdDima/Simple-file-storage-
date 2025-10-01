namespace Models.Factories
{
    public class JwtSettingsFactory : IJwtSettingsFactory
    {
        private readonly IConfiguration _configuration;
        
        public JwtSettingsFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtSettingsDto GetJwtSettings()
        {
            return _configuration.GetSection("Jwt").Get<JwtSettingsDto>();
        }
    }
}