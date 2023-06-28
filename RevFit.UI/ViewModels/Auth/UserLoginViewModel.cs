using System.ComponentModel.DataAnnotations;

namespace RevFit.UI.ViewModels.Auth
{
    public class UserLoginViewModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
