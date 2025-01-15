
using DemoMvc14.Models.SharedProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMvc14.Models
{
    public class Employee:BaseProp
    {
        [Display(Name = "Employee ID")]
        public Guid EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Enter Employee Name")]
        [MinLength(3, ErrorMessage = "At least Name 3 Char")]
        public string EmployeeName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Select Gender")]
        public Genders Gender { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        [Range(0.01,100000,ErrorMessage ="Out of range")]
        public decimal? Salary { get; set; }

        // ------- Join Employee and Department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        // ---------------------
        public enum Genders
        {
            Male, Female
        }
    }
}
