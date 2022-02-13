using System.ComponentModel.DataAnnotations;

namespace SistemaDeLogin.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required, MaxLength(256), EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Constraseña")]
        public string Password { get; set; }

        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Constraseña")]
        [Compare("Password", ErrorMessage = "Las constraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}
