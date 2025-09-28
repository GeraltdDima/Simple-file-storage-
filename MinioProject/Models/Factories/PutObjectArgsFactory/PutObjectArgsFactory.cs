using Minio.DataModel.Args;

namespace Models.Factories
{
    public class PutObjectArgsFactory : IPutObjectArgsFactory
    {
        public PutObjectArgs CreatePutObjectArgs(MinioUploadDto minioUploadDto, Stream stream)
        {
            var bucket = minioUploadDto.Bucket;
            var file = minioUploadDto.File;

            return new PutObjectArgs()
                .WithBucket(bucket)
                .WithObject(file.FileName)
                .WithStreamData(stream)
                .WithObjectSize(stream.Length)
                .WithContentType(file.ContentType);
        }
    }
}