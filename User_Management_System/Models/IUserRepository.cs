namespace User_Management_System.Models
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        void getUserById(string id);
    }
}
