namespace Models
{
    public class MinioDownloadDto
    {
        public MinioDownloadDto(string fileName, string bucket)
        {
            FileName = fileName;
            Bucket = bucket;
        }

        public string FileName { get; set; }
        public string Bucket { get; set; }
    }
}