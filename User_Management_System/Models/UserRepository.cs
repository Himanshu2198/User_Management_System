using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
//using System.Configuration;

namespace User_Management_System.Models
{
    public class UserRepository:IUserRepository
    {
        private SqlConnection con;
        //private readonly IConfiguration _configuration;

        private void connection()
        {
            /*string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            string? connectionString = configuration.GetConnectionString("getconn");

            con = new SqlConnection(connetionString);
*/
            con = new SqlConnection(@"Data Source=192.168.0.89;Initial Catalog=Userdb;User ID=sa;password=droisys@4800");

        }

        public void AddUser(User user)
        {
            connection();
            SqlCommand cmd = new SqlCommand("InsertUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("userName", user.UserName);
            cmd.Parameters.AddWithValue("email", user.Email);
            cmd.Parameters.AddWithValue("pass", user.Password);
            cmd.Parameters.AddWithValue("DOB", user.DOB);
            cmd.Parameters.AddWithValue("gen", user.Gender);
            cmd.Parameters.AddWithValue("contact", user.Phone);
            cmd.Parameters.AddWithValue("DeptId", user.DeptName);

            con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                Console.WriteLine("Record Inserted Succesfully into the Database");
            }
            con.Close();
            return;
        }

        public void UpdateUser(User user)
        {
            connection();
            SqlCommand cmd = new SqlCommand("updateUser",con);
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue ("@userId", user.UserId);
            cmd.Parameters.AddWithValue ("@username", user.UserName);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@pass", user.Password);
            cmd.Parameters.AddWithValue("@DOB", user.DOB);
            cmd.Parameters.AddWithValue("@gen", user.Gender);
            cmd.Parameters.AddWithValue("@contact", user.Phone);
            cmd.Parameters.AddWithValue("@DeptId", user.DeptName);
            con.Open() ;
            cmd.ExecuteNonQuery();
            return;

        }
        public void DeleteUser(User user) { return; }
        public SqlDataReader getUserDetails(string uname, string pass)
        {
            connection();
            SqlCommand cmd = new SqlCommand("userDetails",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("userName", uname);
            cmd.Parameters.AddWithValue("pass", pass);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            var result = reader;
   
            //con.Close();
            return reader;
        }
    }
}
