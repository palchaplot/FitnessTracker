using UserService.DTO;
using UserService.Models;
using UserService.Repositories.Interfaces;
using UserService.Services.Interfaces;

namespace UserService.Services
{
    public class GoalService :IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<IEnumerable<Goal>> GetByUserIdAsync(int userId)
        {
            return await _goalRepository.GetByUserIdAsync(userId);
        }

        public async Task<Goal?> GetByIdAsync(int id)
        {
            return await _goalRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CreateGoal dto, int userId)
        {
            var goal = new Goal
            {
                GoalType = dto.GoalType,
                TargetValue = dto.TargetValue,
                StartDate = DateTime.UtcNow,
                EndDate = dto.EndDate,
                UserId = userId
            };

            await _goalRepository.AddAsync(goal);
        }

        public async Task UpdateAsync(int id, UpdateGoal dto)
        {
            var goal = await _goalRepository.GetByIdAsync(id);

            if (goal == null)
                throw new Exception("Goal not found");

            goal.GoalType = dto.GoalType;
            goal.TargetValue = dto.TargetValue;
            goal.EndDate = dto.EndDate;

            await _goalRepository.UpdateAsync(goal);
        }

        public async Task DeleteAsync(int id)
        {
            var goal = await _goalRepository.GetByIdAsync(id);

            if (goal == null)
                throw new Exception("Goal not found");

            await _goalRepository.DeleteAsync(goal);
        }
    }
}
