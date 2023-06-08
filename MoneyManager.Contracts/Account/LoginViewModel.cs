using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Contracts.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "The email address is required")]
    [Display(Name = "Email address")]
    [EmailAddress(ErrorMessage = "Invalid Email or password")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}