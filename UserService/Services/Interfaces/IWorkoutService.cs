using UserService.DTO;
using UserService.Models;

namespace UserService.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<IEnumerable<Workout>> GetAllAsync();

        Task<IEnumerable<Workout>> GetByUserIdAsync(int userId);
        Task<Workout?> GetByIdAsync(int id);

        Task AddAsync(CreateWorkout dto, int userId);

        Task UpdateAsync(int id, UpdateWorkout dto);

        Task DeleteAsync(int id);
    }
}
