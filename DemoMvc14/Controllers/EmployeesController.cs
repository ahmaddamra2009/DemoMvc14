using DemoMvc14.Data;
using DemoMvc14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            return View(db.Employees.Include(x => x.Department));

        }

        public IActionResult Create()
        {
            ViewBag.dept = new SelectList(db.Departments.
                Where(x => x.IsActive == true && x.IsDeleted == false), "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            if (ModelState.IsValid)
            {

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult DepartmentEmployees(int? id)
        {
            if (id == null || !id.HasValue)
            {
                return RedirectToAction(nameof(Index));
            }
            var data = db.Employees.Where
                (x => x.DepartmentId == id).
                Include(x => x.Department);
            if (data == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DeptName = db.Departments.
                Where(x => x.DepartmentId == id).
                Select(c => c.DepartmentName).FirstOrDefault();

            return View(data);
        }

    }
}
