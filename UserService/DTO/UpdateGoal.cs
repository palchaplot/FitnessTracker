using System.ComponentModel.DataAnnotations;

namespace UserService.DTO
{
    public class UpdateGoal
    {
        [Required]
        public string GoalType { get; set; } = string.Empty;

        [Range(0,10000)]
        public double TargetValue { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
