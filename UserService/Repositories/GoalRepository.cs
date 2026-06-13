using UserService.Data;
using UserService.Models;
using UserService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UserService.Repositories
{
    public class GoalRepository :IGoalRepository
    {

        private readonly AppDbContext _context;

        public GoalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Goal>> GetByUserIdAsync(int userId)
        {
            return await _context.Goals
                .Where(g => g.UserId == userId)
                .ToListAsync();
        }

        public async Task<Goal?> GetByIdAsync(int id)
        {
            return await _context.Goals.FindAsync(id);
        }

        public async Task AddAsync(Goal goal)
        {
            await _context.Goals.AddAsync(goal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Goal goal)
        {
            _context.Goals.Update(goal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Goal goal)
        {
            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
        }
    }
}
