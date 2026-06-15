using UserService.DTO;
namespace UserService.Services.Interfaces
{
    public interface IDashboardService
    {

        Task<Dashboard> GetDashboardAsync(int userId);
    }
}
