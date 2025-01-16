using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMvc14.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Enter Name")]
        [MinLength(3, ErrorMessage = "Min 3 Char")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Confirm Email")]
        [EmailAddress]
        [Display(Name = "Confirm Email Address")]
        [Compare("Email",ErrorMessage ="Email and Confirm Email not match")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password not match")]
        public string ConfirmPassword { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
