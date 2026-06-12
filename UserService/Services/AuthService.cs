using UserService.DTO;
using UserService.Models;
using UserService.Repositories.Interfaces;
using UserService.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace UserService.Services
{
    public class AuthService:IAuthService

    {
		private readonly IUserRepository _userRepository;
		private readonly IConfiguration _configuration;

		public AuthService(IUserRepository userRepository, IConfiguration configuration)
		{
			_userRepository = userRepository;
			_configuration = configuration;
		}

		public async Task RegisterAsync(Register dto)
		{
			var existingUser =
				await _userRepository.GetByEmailAsync(dto.Email);

			if (existingUser != null)
			{
				throw new Exception("User already exists");
			}

			var user = new User
			{
				Name = dto.Name,
				Email = dto.Email,
				Password = dto.Password
			};

			await _userRepository.AddUserAsync(user);
		}

		public async Task<string?> LoginAsync(Login dto)
		{
			var user = await _userRepository.GetByEmailAsync(dto.Email);
			if (user == null)
			{
				return null;
			}
			if(user.Password != dto.Password)
			{
				return null;
			}
			return GenerateJwtToken(user);
		}

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),

               new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var creds = new SigningCredentials( key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
