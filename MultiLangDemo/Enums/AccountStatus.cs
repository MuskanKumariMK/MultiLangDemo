using System.ComponentModel.DataAnnotations;

namespace MultiLangDemo.Enums
{
    public enum AccountStatus
    {
        [Display(Name = "Active")]
        Active,

        [Display(Name = "Pending")]
        Pending,

        [Display(Name = "Blocked")]
        Blocked
    }
}
