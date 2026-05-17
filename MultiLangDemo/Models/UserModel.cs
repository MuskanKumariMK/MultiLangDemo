using MultiLangDemo.Enums;
using System.ComponentModel.DataAnnotations;

namespace MultiLangDemo.Models
{
    public class UserModel
    {
        [Display(Name = "Email")]
        [Required(
            ErrorMessage = "EmailRequired")]

        [EmailAddress(
            ErrorMessage = "ValidEmail")]

        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(
            ErrorMessage = "PasswordRequired")]

        [MinLength(6,
            ErrorMessage = "PasswordLength")]

        public string Password { get; set; }
        [Display(Name = "RememberMe")]

        public bool RememberMe { get; set; }
        [Display(Name = "AccountStatus")]
        public AccountStatus Status { get; set; }
    }
}
