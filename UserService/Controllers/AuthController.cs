using Microsoft.AspNetCore.Mvc;
using UserService.DTO;
using UserService.Services.Interfaces;


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

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (!result)
            {
                return BadRequest("Invalid User or Password");
            }

            return Ok("Login Successfull");
        }
    }
}
