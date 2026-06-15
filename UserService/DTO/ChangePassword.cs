using System.ComponentModel.DataAnnotations;

namespace UserService.DTO
{
    public class ChangePassword
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string NewPassword { get; set; } = string.Empty;

    }
}
