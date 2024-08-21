using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
//using System.Configuration;

namespace User_Management_System.Models
{
    public class UserRepository:IUserRepository
    {
        /*private SqlConnection con;


        private void connection()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            string? connectionString = configuration.GetConnectionString("getconn");

            con = new SqlConnection(connectionString);
            
        }*/
        public void AddUser(User user)
        {
           /* SqlCommand cmd = new SqlCommand("InsertUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("name", username.Text);
            cmd.Parameters.AddWithValue("email", TextBox2.Text);
            cmd.Parameters.AddWithValue("education", TextBox3.Text);
            cmd.Parameters.AddWithValue("phoneno", TextBox4.Text);
            cmd.Parameters.AddWithValue("city", TextBox5.Text);
            con.Open();
            return;*/
        }

        public void UpdateUser(User user)
        {
            return;
        }
        public void DeleteUser(User user) { return; }
        public void getUserById(string id)
        {
            return;
        }
        public User DisplayUser()
        {
            User myUser1 = new User();
            SqlConnection con = new SqlConnection(@"Data Source=192.168.0.89;Initial Catalog=Userdb;User ID=sa;password=droisys@4800");
            SqlCommand cmd = new SqlCommand("userDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("userId", myUser1.UserId);
            con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader != null)
                {
                    dataReader.Read();
                }
            myUser1.UserId = dataReader["UserId"].ToString();
            myUser1.UserName = dataReader["UserName"].ToString();
            myUser1.Email = dataReader["Email"].ToString();
            myUser1.DOB = dataReader["DOB"].ToString();
            myUser1.Gender= dataReader["Gender"].ToString();
            myUser1.Phone= dataReader["ContactNumber"].ToString();
            myUser1.DeptName = dataReader["DeptId"].ToString() ;
            //TempData["username"] = dataReader["ussername"]
            con.Close();
            return myUser1;
            
        }
    }
}
