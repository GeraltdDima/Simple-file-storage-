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
    public class BucketsController : ControllerBase
    {
        private readonly IBucketsService _bucketsService;
        private readonly ISignalRService _signalRService;
        
        public BucketsController(IBucketsService bucketsService, ISignalRService signalRService)
        {
            _bucketsService = bucketsService;
            _signalRService = signalRService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBucketAsync([FromBody] MinioBucketDto bucketDto)
        {
            var result = await _bucketsService.CreateBucketAsync(bucketDto);
            
            if (result.Result == MinioResult.Failure)
                return BadRequest();
            
            var message = new MessageDto("Bucket created: " + bucketDto.BucketName);

            _signalRService.SendMessageAsync(message);
            return Ok(result);
        }
    }
}