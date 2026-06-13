namespace UserService.Models
{
    public class Goal
    {
        public int GoalId { get; set; }

        public string GoalType { get; set; } = string.Empty;

        public double TargetValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
