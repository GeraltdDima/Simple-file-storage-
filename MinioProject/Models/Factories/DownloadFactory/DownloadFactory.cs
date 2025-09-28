using Minio;

namespace Models.Factories
{
    public class DownloadFactory : IDownloadFactory
    {
        private readonly IMinioClient _minioClient;
        private readonly IGetObjectArgsFactory _getObjectArgsFactory;

        public DownloadFactory(IMinioClient minioClient, IGetObjectArgsFactory getObjectArgsFactory)
        {
            _minioClient = minioClient;
            _getObjectArgsFactory = getObjectArgsFactory;
        }

        public async Task<MinioDownloadResultDto> DownloadFileAsync(MinioDownloadDto downloadDto)
        {
            var ms = new MemoryStream();
            
            var getObjectArgs = _getObjectArgsFactory.CreateGetObjectArgs(downloadDto, ms);

            await _minioClient.GetObjectAsync(getObjectArgs);
            
            ms.Position = 0;
            
            return new MinioDownloadResultDto(ms, "application/octet-stream", downloadDto.FileName);
        }
    }
}