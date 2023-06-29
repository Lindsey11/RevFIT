using System.ComponentModel.DataAnnotations;

namespace RevFit.Client.UI.ViewModels.Auth
{
    public class UIUserLoginViewModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
