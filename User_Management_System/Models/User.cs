﻿namespace User_Management_System.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string DeptName {  get; set; }
    }
}
