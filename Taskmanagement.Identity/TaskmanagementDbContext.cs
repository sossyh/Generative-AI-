using Taskmanagement.Identity.Configurations;
using Taskmanagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Taskmanagement.Identity;

public class TaskmanagementIdentityDbContext : IdentityDbContext<User>
{
    public TaskmanagementIdentityDbContext(DbContextOptions<TaskmanagementIdentityDbContext> options) :
        base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new UserRoleConfiguration());
    }
}