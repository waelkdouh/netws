using System.ComponentModel.DataAnnotations;

namespace MyShuttle.Web.Models
{
    public abstract class BasePasswordModel
    {
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long  and no more than 100", MinimumLength = 6)]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long and no more than 30", MinimumLength = 3)]
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class LoginViewModel : BasePasswordModel
    {
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : BasePasswordModel
    {
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
