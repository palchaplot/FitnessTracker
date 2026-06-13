using UserService.Data;
using UserService.Models;
using UserService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UserService.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext _context;

        public WorkoutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workout>> GetAllAsync()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workout?> GetByIdAsync(int id)
        {
            return await _context.Workouts.FindAsync(id);
        }

        public async Task<IEnumerable<Workout>> GetByUserIdAsync(int userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Workout workout)
        {
            await _context.Workouts.AddAsync(workout);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Workout workout)
        {
            _context.Workouts.Update(workout);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Workout workout)
        {
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
        }

    }
}
