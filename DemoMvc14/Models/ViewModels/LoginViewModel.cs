using System.ComponentModel.DataAnnotations;

namespace DemoMvc14.Models.ViewModels
{
    public class LoginViewModel
    {
       
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
