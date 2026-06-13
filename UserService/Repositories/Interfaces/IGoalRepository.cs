using UserService.Models;
namespace UserService.Repositories.Interfaces
{
    public interface IGoalRepository

    {
        Task<IEnumerable<Goal>> GetByUserIdAsync(int userId);
        Task<Goal?> GetByIdAsync(int id);

        Task AddAsync(Goal goal);
        Task UpdateAsync(Goal goal);
        Task DeleteAsync(Goal goal);

    }
}
