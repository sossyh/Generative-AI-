using System;
using Taskmanagement.Domain.Common;

namespace Taskmanagement.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Full_Name { get; set; }
    }
}