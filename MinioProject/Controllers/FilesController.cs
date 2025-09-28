using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IMinioService _minioService;
        
        public FilesController(IMinioService minioService)
        {
            _minioService = minioService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAsync([FromBody] MinioUploadDto uploadDto)
        {
            var result = await _minioService.UploadFileAsync(uploadDto);
            
            if (result.Result == MinioResult.Failure)
                return BadRequest(result);
            
            return Ok(result);
        }

        [HttpGet("download/{bucketName}/{fileName}")]
        public async Task<IActionResult> DownloadAsync(string bucketName, string fileName)
        {
            var downloadDto = new MinioDownloadDto(fileName, bucketName);
            
            var result = await _minioService.DownloadFileAsync(downloadDto);
            
            return File(result.MemoryStream, result.ContentType, result.FileName);
        }
    }
}