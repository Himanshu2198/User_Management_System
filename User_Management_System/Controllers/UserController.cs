using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using User_Management_System.Models;

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

        [HttpPost]
        public IActionResult RedirectToHome(string userName, string pwd)
        {
            SqlDataReader res = newUser.getUserDetails(userName, pwd);
            if (res.HasRows)
            {
                TempData["user"] = userName;
                User myu1 =newUser.DisplayUser(userName, pwd);
                Console.WriteLine(myu1.UserName);
                TempData["userName"] = myu1.UserName;
                TempData["userId"] = myu1.UserId;
                TempData["Email"] = myu1.Email;
                TempData["Gender"]=myu1.Gender;
                TempData["DOB"] = myu1.DOB;
                TempData["Phone"] = myu1.Phone;
                TempData["DeptName"] = myu1.DeptName;
                Console.WriteLine(TempData["userId"]);
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
