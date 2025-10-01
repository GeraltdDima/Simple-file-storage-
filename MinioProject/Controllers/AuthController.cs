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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            
            if (result.Result == AuthResult.UserNotFound)
                return NotFound();
            
            if (result.Result == AuthResult.Failure)
                return BadRequest("Invalid login attempt.");
            
            return Ok(result.AccessToken);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);

            if (result.Result == AuthResult.Failure)
            {
                string errors = string.Join(Environment.NewLine, result.Errors);
                
                _logger.LogError(errors);
                
                return BadRequest("Registration failed. ");
            }
            
            return Ok("Registration successful.");
        }
    }
}