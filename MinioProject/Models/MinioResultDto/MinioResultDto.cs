using Models.Enums;

namespace Models
{
    public class MinioResultDto
    {
        public MinioResultDto(MinioResult result)
        {
            Result = result;
        }
        
        public MinioResult Result { get; set; }
    }
}