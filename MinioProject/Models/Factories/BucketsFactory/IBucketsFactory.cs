namespace Models.Factories
{
    public interface IBucketsFactory
    {
        Task<MinioResultDto> CreateBucketAsync(MinioBucketDto bucketDto);
    }
}