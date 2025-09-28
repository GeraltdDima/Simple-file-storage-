using Minio.DataModel.Args;

namespace Models.Factories
{
    public interface IGetObjectArgsFactory
    {
        GetObjectArgs CreateGetObjectArgs(MinioDownloadDto minioDownloadDto, MemoryStream stream);
    }
}