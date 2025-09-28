namespace Models.Factories
{
    public interface IDownloadFactory
    {
        Task<MinioDownloadResultDto> DownloadFileAsync(MinioDownloadDto downloadDto);
    }
}