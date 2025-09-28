using Minio;
using Minio.DataModel.Args;
using Models.Enums;

namespace Models.Factories
{
    public class BucketsFactory : IBucketsFactory
    {
        private readonly IMinioClient _minioClient;
        
        public BucketsFactory(IMinioClient minioClient)
        {
            _minioClient = minioClient;
        }

        public async Task<MinioResultDto> CreateBucketAsync(MinioBucketDto bucketDto)
        {
            string bucketName = bucketDto.BucketName;
            
            bool found = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));

            if (found)
                return new MinioResultDto(MinioResult.Failure);
            
            await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
            
            return new MinioResultDto(MinioResult.Success);
        }
    }
}