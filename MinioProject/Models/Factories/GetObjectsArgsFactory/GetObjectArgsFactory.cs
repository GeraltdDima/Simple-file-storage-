using Minio.DataModel.Args;

namespace Models.Factories
{
    public class GetObjectArgsFactory : IGetObjectArgsFactory
    {
        public GetObjectArgs CreateGetObjectArgs(MinioDownloadDto minioDownloadDto, MemoryStream stream)
        {
            var bucket = minioDownloadDto.Bucket;
            var fileName = minioDownloadDto.FileName;

            return new GetObjectArgs()
                .WithBucket(bucket)
                .WithObject(fileName)
                .WithCallbackStream(stream => stream.CopyTo(stream));
        }
    }
}