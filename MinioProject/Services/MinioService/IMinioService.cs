using Models;

namespace Services
{
    public interface IMinioService
    {
        Task<MinioResultDto> UploadFileAsync(MinioUploadDto uploadDto);
        Task<MinioDownloadResultDto> DownloadFileAsync(MinioDownloadDto downloadDto);
    }
}