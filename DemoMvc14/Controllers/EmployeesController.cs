using DemoMvc14.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMvc14.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db;
        public EmployeesController(ApplicationDbContext _db)
        {
            db = _db;   
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.dept = new SelectList(db.Departments.
                Where(x => x.IsActive==true && x.IsDeleted == false), "DepartmentId", "DepartmentName");
            return View();
        }
    }
}
