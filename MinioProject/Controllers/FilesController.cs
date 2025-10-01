using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using Services;

namespace Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IMinioService _minioService;
        private readonly ISignalRService _signalRService;
        
        public FilesController(IMinioService minioService, ISignalRService signalRService)
        {
            _minioService = minioService;
            _signalRService = signalRService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAsync([FromBody] MinioUploadDto uploadDto)
        {
            var result = await _minioService.UploadFileAsync(uploadDto);
            
            if (result.Result == MinioResult.Failure)
                return BadRequest(result);
            
            var message = new MessageDto("File uploaded: " + uploadDto.File.FileName);
            
            await _signalRService.SendMessageAsync(message);
            
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