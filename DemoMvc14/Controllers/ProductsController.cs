using DemoMvc14.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc14.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db;
        public ProductsController(ApplicationDbContext _db)
        {
            db=_db;
        }

        public IActionResult Index()
        {
            
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("name")))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Name = HttpContext.Session.GetString("name");
           
            return View(db.Products);
        }
    }
}
