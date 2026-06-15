using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserService.DTO;
using UserService.Models;
using UserService.Services.Interfaces;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var goals = await _goalService.GetByUserIdAsync(userId);

            return Ok(goals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var goal = await _goalService.GetByIdAsync(id);

            if (goal == null)
                return NotFound();

            if (goal.UserId != userId)
                return Forbid();

            return Ok(goal);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGoal dto)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _goalService.AddAsync(dto, userId);

            return Ok("Goal Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateGoal dto)
        {
            var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var goal = await _goalService.GetByIdAsync(id);

            if (goal == null)
                return NotFound();

            if (goal.UserId != userId)
                return Forbid();

            await _goalService.UpdateAsync(id, dto);

            return Ok("Goal Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var goal = await _goalService.GetByIdAsync(id);

            if (goal == null)
                return NotFound();

            if (goal.UserId != userId)
                return Forbid();

            await _goalService.DeleteAsync(id);

            return Ok("Goal Deleted Successfully");
        }
    }
}
