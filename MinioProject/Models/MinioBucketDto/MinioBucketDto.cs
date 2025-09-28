namespace Models
{
    public class MinioBucketDto
    {
        public MinioBucketDto(string bucketName)
        {
            BucketName = bucketName;
        }
        
        public string BucketName { get; set; }
    }
}