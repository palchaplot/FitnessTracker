using UserService.DTO;
using UserService.Models;
using UserService.Repositories.Interfaces;
using UserService.Services.Interfaces;

namespace UserService.Services
{
    public class WorkoutService : IWorkoutService

    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<IEnumerable<Workout>> GetAllAsync()
        {
            return await _workoutRepository.GetAllAsync();
        }

        public async Task<Workout?> GetByIdAsync(int id)
        {
            return await _workoutRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CreateWorkout dto)
        {
            var workout = new Workout
            {
                ExerciseName = dto.ExerciseName,
                Duration = dto.Duration,
                CaloriesBurned = dto.CaloriesBurned,
                WorkoutDate = DateTime.UtcNow
            };

            await _workoutRepository.AddAsync(workout);
        }

        public async Task UpdateAsync(int id, UpdateWorkout dto)
        {
            var workout = await _workoutRepository.GetByIdAsync(id);

            if (workout == null)
            {
                throw new Exception("Workout not found");
            }

            workout.ExerciseName = dto.ExerciseName;
            workout.Duration = dto.Duration;
            workout.CaloriesBurned = dto.CaloriesBurned;
            

            await _workoutRepository.UpdateAsync(workout);
        }

        public async Task DeleteAsync(int id)
        {
            var workout = await _workoutRepository.GetByIdAsync(id);

            if (workout == null)
            {
                throw new Exception("Workout not found");
            }

            await _workoutRepository.DeleteAsync(workout);
        }
    }
}
