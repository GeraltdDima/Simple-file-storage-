using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BucketsController : ControllerBase
    {
        private readonly IBucketsService _bucketsService;
        
        public BucketsController(IBucketsService bucketsService)
        {
            _bucketsService = bucketsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBucketAsync([FromBody] MinioBucketDto bucketDto)
        {
            var result = await _bucketsService.CreateBucketAsync(bucketDto);
            
            if (result.Result == MinioResult.Failure)
                return BadRequest();

            return Ok(result);
        }
    }
}