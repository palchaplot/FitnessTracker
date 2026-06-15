using System.Threading.Tasks;
using UserService.DTO;
namespace UserService.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(Register dto);
        Task<string> LoginAsync(Login dto);
        Task<UserProfileDto?> GetProfileAsync(int userId);

        Task UpdateProfileAsync(int userId, UpdateProfile dto);

        Task ChangePasswordAsync(int userId, ChangePassword dto);

        Task DeleteAccountAsync(int userId);


    }
}
