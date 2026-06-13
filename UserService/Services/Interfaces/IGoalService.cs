using UserService.DTO;
using UserService.Models;


namespace UserService.Services.Interfaces
{
    public interface IGoalService
    {
        Task<IEnumerable<Goal>> GetByUserIdAsync(int userId);

        Task<Goal?> GetByIdAsync(int id);

        Task AddAsync(CreateGoal dto, int userId);

        Task UpdateAsync(int id, UpdateGoal dto);

        Task DeleteAsync(int id);
    }
}
