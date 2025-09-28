namespace Models
{
    public class MinioDownloadResultDto
    {
        public MinioDownloadResultDto(MemoryStream memoryStream, string contentType, string fileName)
        {
            MemoryStream = memoryStream;
            ContentType = contentType;
            FileName = fileName;
        }

        public MemoryStream MemoryStream { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}