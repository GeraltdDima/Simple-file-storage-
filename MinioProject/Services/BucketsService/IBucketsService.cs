using Models;

namespace Services
{
    public interface IBucketsService
    {
        Task<MinioResultDto> CreateBucketAsync(MinioBucketDto bucketDto);
    }
}