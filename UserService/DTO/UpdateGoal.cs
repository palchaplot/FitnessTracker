namespace UserService.DTO
{
    public class UpdateGoal
    {
        public string GoalType { get; set; } = string.Empty;

        public double TargetValue { get; set; }

        public DateTime EndDate { get; set; }
    }
}
