using Microsoft.AspNetCore.Mvc;
using DAMBackend.auth;

namespace backend.auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _authService = new AuthService();
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginRequest request)
        {
            var result = await _authService.RegisterUserAsync(request.Email, request.Password);
            return result ? Ok("User registered successfully") : BadRequest("Email already exists");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.AuthenticateUserAsync(request.Email, request.Password);
            return result ? Ok("Login successful") : Unauthorized("Invalid email or password");
        }
    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
