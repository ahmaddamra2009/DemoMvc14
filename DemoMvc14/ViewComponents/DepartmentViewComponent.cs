using DemoMvc14.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc14.ViewComponents
{
    public class DepartmentViewComponent : ViewComponent
    {
        private ApplicationDbContext db;
        public DepartmentViewComponent(ApplicationDbContext _db)
        {
            db=_db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Departments);
        }
    }
}
