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
				Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
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
			if(!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
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
        public async Task<UserProfileDto?> GetProfileAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            return new UserProfileDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task UpdateProfileAsync(int userId, UpdateProfile dto)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
                throw new Exception("User not found");

            user.Name = dto.Name;
            user.Email = dto.Email;

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task ChangePasswordAsync(int userId, ChangePassword dto)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
                throw new Exception("User not found");

            if (!BCrypt.Net.BCrypt.Verify(
                    dto.CurrentPassword,
                    user.Password))
            {
                throw new Exception("Current password is incorrect");
            }

            user.Password =
                BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteAccountAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
                throw new Exception("User not found");

            await _userRepository.DeleteUserAsync(user);
        }
    }
}
