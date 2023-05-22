using Taskmanagement.Application.Features.User.DTOs;
namespace Taskmanagement.Application.Features.User.DTOs;

public class UserDetailsDto
{
    public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Full_Name { get; set; }
    }