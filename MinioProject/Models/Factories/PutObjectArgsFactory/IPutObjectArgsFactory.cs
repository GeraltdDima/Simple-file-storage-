using Minio.DataModel.Args;

namespace Models.Factories
{
    public interface IPutObjectArgsFactory
    {
        PutObjectArgs CreatePutObjectArgs(MinioUploadDto minioUploadDto, Stream stream);
    }
}