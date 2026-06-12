using System.ComponentModel.DataAnnotations;

namespace UserService.DTO
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
