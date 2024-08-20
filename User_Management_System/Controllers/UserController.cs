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

        [HttpPost]
        public IActionResult RedirectToHome(string userId, string pwd)
        {
            TempData["user"] = userId;
            return RedirectToAction("Index");

        }
        public IActionResult Register()
        {
            return View();
        }

        public User myUser; 
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
            AddUser();
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


        /*private SqlConnection con;


        private void connection()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            string connectionString = configuration.GetConnectionString("getconn");

            con = new SqlConnection(connectionString);

        }*/
        public void AddUser()
        {
            SqlConnection con = new SqlConnection(@"Data Source=192.168.0.89;Initial Catalog=Userdb;User ID=sa;password=droisys@4800");
            SqlCommand cmd = new SqlCommand("InsertUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("userName", myUser.UserName);
            cmd.Parameters.AddWithValue("email", myUser.Email);
            cmd.Parameters.AddWithValue("pass", myUser.Password);
            cmd.Parameters.AddWithValue("DOB", myUser.DOB);
            cmd.Parameters.AddWithValue("gen", myUser.Gender);
            cmd.Parameters.AddWithValue("contact", myUser.Phone);
            cmd.Parameters.AddWithValue("DeptId", myUser.DeptName );
            con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                Console.WriteLine("Record Inserted Succesfully into the Database");
            }
            con.Close();
            return;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
