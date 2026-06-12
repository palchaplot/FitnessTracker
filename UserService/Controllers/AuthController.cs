using Microsoft.AspNetCore.Mvc;
using UserService.DTO;
using UserService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace UserService.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(Register dto)
        {
            await _authService.RegisterAsync(dto);
            return Ok("User Registered Successfully");

        }
        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok("You are Authenticated");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login dto)
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
            {
                return Unauthorized("Invalid Email or Password");
            }

            return Ok(new
            {
                Token = token
            });
        }
    }
}
