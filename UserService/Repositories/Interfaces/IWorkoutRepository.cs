using UserService.Models;
namespace UserService.Repositories.Interfaces
{
    public interface IWorkoutRepository

    {
        Task<IEnumerable<Workout>> GetAllAsync();
        Task<IEnumerable<Workout>> GetByUserIdAsync(int userId);
        Task<Workout?> GetByIdAsync(int id);

        Task AddAsync(Workout workout);

        Task UpdateAsync(Workout workout);

        Task DeleteAsync(Workout workout);
    }
}
