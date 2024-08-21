using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using User_Management_System.Models;
using System.Numerics;
using System.Reflection;

namespace User_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
       


        public UserController(ILogger<UserController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            
        }

        public IActionResult Index()
        {
            var user = TempData["user"];
            ViewBag.UserId = user;
            return View();
        }
    
        [HttpPost]
        public IActionResult Index(string username, string email, DateOnly dob, string gender, string department, string phone)
        {
            myUser = new User();
            myUser.UserName = username;
            myUser.Email = email;
          
            myUser.DOB = dob.ToString();
            myUser.Gender = gender;
            myUser.DeptName = department;
            myUser.Phone = phone;

            //TempData["newuser"] = myUser;
            newUser.UpdateUser(myUser);
            return RedirectToAction("Register");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RedirectToHome(string userName, string pwd)
        {
            SqlDataReader res = newUser.getUserDetails(userName, pwd);
            if (res.HasRows)
            {
                TempData["user"] = userName;

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid user";
                return View("Login");
            }

        }
        public IActionResult Register()
        {
            return View();
        }

        public User myUser; 
        UserRepository newUser = new UserRepository();
        [HttpPost]
        public IActionResult RedirectToLogin(string username,string email,string password,DateOnly dob,string Gender, string Department,string phone)
        {
            myUser = new User();
            myUser.UserName = username;
            myUser.Email = email;
            myUser.Password = password;
            myUser.DOB = dob.ToString();
            myUser.Gender = Gender;
            myUser.DeptName = Department;
            myUser.Phone = phone;

            //TempData["newuser"] = myUser;
            newUser.AddUser(myUser);
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
        public IActionResult UserList()

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
