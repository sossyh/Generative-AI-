using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Taskmanagement.Identity;


public class TaskmanagementIdentityDbContextFactory : IDesignTimeDbContextFactory<TaskmanagementIdentityDbContext>
{
    public TaskmanagementIdentityDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../Taskmangement.Api")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<TaskmanagementIdentityDbContext>();
        var connectionString = configuration.GetConnectionString("TaskmanagementIdentityConnectionString");

        builder.UseNpgsql(connectionString);

        return new TaskmanagementIdentityDbContext(builder.Options);
    }
}
