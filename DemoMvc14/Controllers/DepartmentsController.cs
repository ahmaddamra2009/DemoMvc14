using DemoMvc14.Data;
using DemoMvc14.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc14.Controllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext db;
        public DepartmentsController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()    
        {
            ViewBag.total=db.Departments.Where(x=>x.IsDeleted==true).Count();

            return View(db.Departments.
                Where(d => d.IsDeleted == false).
                OrderByDescending(x => x.CreationDate));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                department.IsActive = true;
                department.IsDeleted = false;
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id < 0) { return RedirectToAction(nameof(Index)); }
            var data = db.Departments.Find(id);
            if (data != null)
            {
                data.IsDeleted = true;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult RestoreDepartments()
        {
            var data = db.Departments.Where(x => x.IsDeleted);
            if (data.Any())
            {
                return View(data);
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult ConfirmRestor(int? id)
        {
            if (id == null || id < 0) { return RedirectToAction(nameof(Index)); }
            var data = db.Departments.Find(id);
            if (data != null)
            {
                data.IsDeleted = false;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
