using DemoMvc14.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace DemoMvc14.ViewComponents
{
    public class EmployeeViewComponent:ViewComponent
    {

        private ApplicationDbContext db;
        public EmployeeViewComponent(ApplicationDbContext _db)
        {
            db= _db;       
        }

        public IViewComponentResult Invoke() 
        {
            return View(db.Employees.Include(x=>x.Department));
        }

    }
}
