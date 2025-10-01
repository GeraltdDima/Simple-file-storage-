namespace Extensions.ConfigurationExtensions
{
    public static class ConfigsExtensions
    {
        public static IConfigurationBuilder UseConfigs(this IConfigurationBuilder configuration)
        {
            foreach (var path in GetPaths())
            {
                configuration.AddJsonFile(path);
            }
            
            return configuration;
        }
        
        private static IEnumerable<string> GetPaths() =>
            GetConfigs()
                .Select(config => GetPath(config));
        
        private static IEnumerable<string> GetConfigs()
        {
            yield return "cors";
            yield return "jwt";
            yield return "smtp";
            yield return "minio";
        }
        
        private static string GetPath(string fileName) => $"./Configs/{fileName}settings.json";
    }
}