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
    }
}
