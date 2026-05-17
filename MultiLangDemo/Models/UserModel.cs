using MultiLangDemo.Enums;
using System.ComponentModel.DataAnnotations;

namespace MultiLangDemo.Models
{
    /// <summary>
    /// ErrorMessageResourceType: typeof(SharedResource) - Specifies the resource type for error messages, allowing for localization.
    /// ErrorMessageResourceName: "EmailRequired", "ValidEmail", "PasswordRequired", "PasswordLength" - Specifies the resource name for the error message, which will be looked up in the specified resource type.
    /// Why Use It ?? : Using resource files for error messages allows you to easily support multiple languages in your application. By defining error messages in a resource file, you can provide translations for different languages without changing the code. This makes it easier to maintain and expand your application to support additional languages in the future.
    /// </summary>
    public class UserModel
    {
        [Display(Name = "Email", ResourceType = typeof(SharedResource))]
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "ValidEmail")]

        public string Email { get; set; }
        [Display(Name = "Password", ResourceType = typeof(SharedResource))]
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "PasswordRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "PasswordLength")]

        public string Password { get; set; }
        [Display(Name = "RememberMe", ResourceType = typeof(SharedResource))]

        public bool RememberMe { get; set; }
        [Display(Name = "AccountStatus", ResourceType = typeof(SharedResource))]
        public AccountStatus Status { get; set; }
    }
}
