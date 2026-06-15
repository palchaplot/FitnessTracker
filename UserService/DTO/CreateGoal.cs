using System.ComponentModel.DataAnnotations;
namespace UserService.DTO
{
    public class CreateGoal
    {
        [Required]
        public string GoalType { get; set; } = string.Empty;

        [Range(0, 100000)]
        public double TargetValue { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
