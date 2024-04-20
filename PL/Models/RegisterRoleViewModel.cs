using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class RegisterRoleViewModel
    {
        [Display(Name = "Role name")]
        [Required]
        public string RoleName { get; set; }
    }
}
