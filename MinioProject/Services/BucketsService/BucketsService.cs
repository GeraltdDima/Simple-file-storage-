using Models.Factories;
using Models;

namespace Services
{
    public class BucketsService : IBucketsService
    {
        private readonly IBucketsFactory _bucketsFactory;
        
        public BucketsService(IBucketsFactory bucketsFactory)
        {
            _bucketsFactory = bucketsFactory;
        }
        
        public async Task<MinioResultDto> CreateBucketAsync(MinioBucketDto bucketDto) =>
            await _bucketsFactory.CreateBucketAsync(bucketDto);
    }
}