using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserService.DTO;
using UserService.Services.Interfaces;


namespace UserService.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class WorkoutController : ControllerBase
        {
            private readonly IWorkoutService _workoutService;

            public WorkoutController(IWorkoutService workoutService)
            {
                _workoutService = workoutService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                 var userId = int.Parse(
                 User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                 var workouts = await _workoutService.GetByUserIdAsync(userId);

                return Ok(workouts);

        }

        [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
            var userId = int.Parse(
             User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var workout = await _workoutService.GetByIdAsync(id);

            if (workout == null)
                return NotFound();

            if (workout.UserId != userId)
                return Forbid();

            return Ok(workout);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkout dto)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _workoutService.AddAsync(dto, userId);

            return Ok("Workout Created Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateWorkout dto)
        {
            var userId = int.Parse(
           User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var workout = await _workoutService.GetByIdAsync(id);

            if (workout == null)
                return NotFound();

            if (workout.UserId != userId)
                return Forbid();

            await _workoutService.UpdateAsync(id, dto);

            return Ok("Workout Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var workout = await _workoutService.GetByIdAsync(id);

            if (workout == null)
                return NotFound();

            if (workout.UserId != userId)
                return Forbid();

            await _workoutService.DeleteAsync(id);

            return Ok("Workout Deleted Successfully");

        }
          
            
        }
    }

