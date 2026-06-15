using UserService.DTO;
using UserService.Repositories.Interfaces;
using UserService.Services.Interfaces;
namespace UserService.Services
{
    public class DashboardService :IDashboardService

    {

        private readonly IWorkoutRepository _workoutRepository;
        private readonly IGoalRepository _goalRepository;

        public DashboardService(
            IWorkoutRepository workoutRepository,
            IGoalRepository goalRepository)
        {
            _workoutRepository = workoutRepository;
            _goalRepository = goalRepository;
        }

        public async Task<Dashboard> GetDashboardAsync(int userId)
        {
            return new Dashboard
            {
                TotalWorkouts =
                    await _workoutRepository.GetTotalWorkoutsAsync(userId),

                TotalWorkoutMinutes =
                    await _workoutRepository.GetTotalWorkoutMinutesAsync(userId),

                TotalCaloriesBurned =
                    await _workoutRepository.GetTotalCaloriesBurnedAsync(userId),

                TotalGoals =
                    await _goalRepository.GetTotalGoalsAsync(userId)
            };
        }
    }
}
