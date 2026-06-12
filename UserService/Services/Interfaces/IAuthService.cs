using System.Threading.Tasks;
using UserService.DTO;
namespace UserService.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(Register dto);
        Task<bool> LoginAsync(Login dto);
    }
}
