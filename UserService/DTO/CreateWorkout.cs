using System.ComponentModel.DataAnnotations;
namespace UserService.DTO
{
    public class CreateWorkout
    {
        [Required]
        public string ExerciseName { get; set; } = string.Empty;

        [Range(0,1000)]
        public int Duration { get; set; }

        [Range(0,100000)]
        public int CaloriesBurned { get; set; }
        
        
    }
}
