using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using User_Management_System.Models;

namespace User_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var user = TempData["user"];
            ViewBag.UserId = user;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

<<<<<<< HEAD:User_Management_System/Controllers/HomeController.cs
=======
        [HttpPost]
        public IActionResult RedirectToHome(string userId,string pwd)
        {
            TempData["user"] = userId;
            return RedirectToAction("Index");
        }

>>>>>>> 86143e37eb05405fae7392141b600c4bba17bc06:User_Management_System/Controllers/UserController.cs
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RedirectToLogin()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Services()

        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
