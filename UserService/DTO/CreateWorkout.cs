namespace UserService.DTO
{
    public class CreateWorkout
    {
        public string ExerciseName { get; set; } = string.Empty;
        public int Duration { get; set; }

        public int CaloriesBurned { get; set; }
        
        
    }
}
