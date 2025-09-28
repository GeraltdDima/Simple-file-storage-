namespace Models.Factories
{
    public interface IUploadFactory
    {
        Task<MinioResultDto> UploadFileAsync(MinioUploadDto uploadDto);
    }
}