using DemoMvc14.Data;
using DemoMvc14.Models;
using DemoMvc14.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMvc14.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db;
        public AccountController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.AllRoles = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    RoleId = model.RoleId,
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
                };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.AllRoles = new SelectList(db.Roles, "RoleId", "RoleName");
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var data = db.Users.Where(x => x.Email == model.Email &&
            x.Password == model.Password);

            if (data.Any()) {
                string Name = data.SingleOrDefault().Name.ToString();
                HttpContext.Session.SetString("name", Name);

                return RedirectToAction("Index", "Products");
            }
            ViewBag.err = "Invalid User or password";
            return View(model);
        }


    }
}
