using System.ComponentModel.DataAnnotations;

namespace DemoMvc14.Models
{
    public class Role
    {
        [Display(Name ="Role ID")]
        public int RoleId { get; set; }
        [Display(Name = "Role Name")]
        [Required(ErrorMessage ="Enter Role Name")]
        public string RoleName { get; set; }
    }
}
