namespace UserService.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string ExerciseName { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int  CaloriesBurned { get; set; } 
        public DateTime WorkoutDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
