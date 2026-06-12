using UserService.DTO;
using UserService.Models;
using UserService.Repositories.Interfaces;
using UserService.Services.Interfaces;
namespace UserService.Services
{
    public class AuthService:IAuthService

    {
		private readonly IUserRepository _userRepository;

		public AuthService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
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

		public async Task<bool> LoginAsync(Login dto)
		{
			var user = await _userRepository.GetByEmailAsync(dto.Email);
			if (user == null)
			{
				return false;
			}
			if(user.Password != dto.Password)
			{
				return false;
			}
			return true;
		}
	}
}
