namespace Models
{
    public class MinioUploadDto
    {
        public MinioUploadDto(string bucket, IFormFile file)
        {
            Bucket = bucket;
            File = file;
        }
        
        public string Bucket { get; set; }
        public IFormFile File { get; set; }
    }
}