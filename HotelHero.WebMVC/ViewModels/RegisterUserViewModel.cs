using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HotelHero.WebMVC.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [StringLength(255, MinimumLength = 8)]
        public string? Password { get; set; }
        [Required]
        [PasswordPropertyText]
        [StringLength(255, MinimumLength = 8)]
        [Compare(nameof(Password))]
        public string? PasswordConfirmation { get; set; }
    }
}
