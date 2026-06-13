namespace UserService.DTO
{
    public class CreateGoal
    {
        public string GoalType { get; set; } = string.Empty;

        public double TargetValue { get; set; }

        public DateTime EndDate { get; set; }
    }
}
