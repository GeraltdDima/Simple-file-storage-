using Models.Factories;
using Models;

namespace Services
{
    public class MinioService : IMinioService
    {
        private readonly IUploadFactory _uploadFactory;
        private readonly IDownloadFactory _downloadFactory;
        
        public MinioService(IUploadFactory uploadFactory, IDownloadFactory downloadFactory)
        {
            _uploadFactory = uploadFactory;
            _downloadFactory = downloadFactory;
        }

        public async Task<MinioResultDto> UploadFileAsync(MinioUploadDto uploadDto) =>
            await _uploadFactory.UploadFileAsync(uploadDto);
        
        public async Task<MinioDownloadResultDto> DownloadFileAsync(MinioDownloadDto downloadDto) =>
            await _downloadFactory.DownloadFileAsync(downloadDto);
    }
}