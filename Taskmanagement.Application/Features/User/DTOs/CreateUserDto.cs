using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Features.User.DTOs
{
    public class CreateUserDto 
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Full_Name { get; set; }
    }
}
