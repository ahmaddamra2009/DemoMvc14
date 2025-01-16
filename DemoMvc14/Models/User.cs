using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMvc14.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage ="Enter Name")]
        [MinLength(3,ErrorMessage ="Min 3 Char")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
