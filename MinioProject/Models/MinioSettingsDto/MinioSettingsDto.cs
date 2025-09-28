namespace Models
{
    public class MinioSettingsDto
    {
        public MinioSettingsDto(string endpoint, string accessKey, string secretKey, bool useSsl)
        {
            Endpoint = endpoint;
            AccessKey = accessKey;
            SecretKey = secretKey;
            UseSSL = useSsl;
        }
        
        public string Endpoint { get; set; }
        
        public string AccessKey { get; set; }
        
        public string SecretKey { get; set; }
        
        public bool UseSSL { get; set; }
    }
}