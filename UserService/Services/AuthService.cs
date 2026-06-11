namespace UserService.Services
{
    public class AuthService:IAuthService

    {
		private readonly IUserRepository _userRepository;

		public AuthService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task RegisterAsync(RegisterDto dto)
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
	}
}
