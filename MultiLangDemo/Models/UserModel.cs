using System.ComponentModel.DataAnnotations;

namespace MultiLangDemo.Models
{
    public class UserModel
    {

        [Required(
            ErrorMessage = "EmailRequired")]

        [EmailAddress(
            ErrorMessage = "ValidEmail")]

        public string Email { get; set; }

        [Required(
            ErrorMessage = "PasswordRequired")]

        [MinLength(6,
            ErrorMessage = "PasswordLength")]

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
