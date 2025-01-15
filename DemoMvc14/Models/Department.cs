using DemoMvc14.Models.SharedProp;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoMvc14.Models
{
    public class Department:BaseProp
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage ="Enter Department Name")]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
    }
}
