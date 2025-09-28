using Minio;
using Models.Enums;

namespace Models.Factories
{
    public class UploadFactory : IUploadFactory
    {
        private readonly IMinioClient _minioClient;
        private readonly IPutObjectArgsFactory _putObjectArgsFactory;

        public UploadFactory(IMinioClient minioClient, IPutObjectArgsFactory putObjectArgsFactory)
        {
            _minioClient = minioClient;
            _putObjectArgsFactory = putObjectArgsFactory;
        }

        public async Task<MinioResultDto> UploadFileAsync(MinioUploadDto uploadDto)
        {
            using var stream = uploadDto.File.OpenReadStream();
            
            var putObjectsArgs = _putObjectArgsFactory.CreatePutObjectArgs(uploadDto, stream);
            
            await _minioClient.PutObjectAsync(putObjectsArgs);

            return new MinioResultDto(MinioResult.Success);
        }
    }
}