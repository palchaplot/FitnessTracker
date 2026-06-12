using UserService.DTO;
using UserService.Models;

namespace UserService.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<IEnumerable<Workout>> GetAllAsync();

        Task<Workout?> GetByIdAsync(int id);

        Task AddAsync(CreateWorkout dto);

        Task UpdateAsync(int id, UpdateWorkout dto);

        Task DeleteAsync(int id);
    }
}
