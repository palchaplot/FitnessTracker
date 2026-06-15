using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Security.Claims;
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
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var userId = int.Parse(
        User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var profile = await _authService.GetProfileAsync(userId);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
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

        [Authorize]
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfile dto)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _authService.UpdateProfileAsync(userId, dto);

            return Ok("Profile Updated Successfully");
        }

        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword( ChangePassword dto)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _authService.ChangePasswordAsync(userId, dto);

            return Ok("Password changed successfully");
        }

        [Authorize]
        [HttpDelete("delete-account")]
        public async Task<IActionResult> DeleteAccount()
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _authService.DeleteAccountAsync(userId);

            return Ok("Account deleted successfully");
        }
    }
}
