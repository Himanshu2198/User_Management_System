using System.Data.SqlClient;
//using System.Configuration;

namespace User_Management_System.Models
{
    public class UserRepository:IUserRepository
    {
        private SqlConnection con;


        private void connection()
        {
            //string constr = ConfigurationManager[ConfigurationManager.ConnectionString]["getconn"];

            //con = new SqlConnection(constr);
        }
        public void AddUser(User user)
        {
            return;
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
