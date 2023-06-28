using System.ComponentModel.DataAnnotations;

namespace RevFit.UI.ViewModels.Auth
{
    public class UserRegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}
