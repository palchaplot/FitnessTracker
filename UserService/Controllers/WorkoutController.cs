using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                var workouts = await _workoutService.GetAllAsync();
                return Ok(workouts);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var workout = await _workoutService.GetByIdAsync(id);

                if (workout == null)
                    return NotFound();

                return Ok(workout);
            }

            [HttpPost]
            public async Task<IActionResult> Create(CreateWorkout dto)
            {
                await _workoutService.AddAsync(dto);

                return Ok("Workout Created Successfully");
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, UpdateWorkout dto)
            {
                await _workoutService.UpdateAsync(id, dto);

                return Ok("Workout Updated Successfully");
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _workoutService.DeleteAsync(id);

                return Ok("Workout Deleted Successfully");
            }
        }
    }

