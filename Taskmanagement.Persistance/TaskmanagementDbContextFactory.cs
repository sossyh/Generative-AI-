using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Taskmanagement.Persistence
{
    public class TaskmanagementDbContextFactory : IDesignTimeDbContextFactory<TaskmanagementDbContext>
    {
        public TaskmanagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory() + "../../Taskmanagement.Api")
                 .AddJsonFile("appsettings.json")
                 .Build();

            var builder = new DbContextOptionsBuilder<TaskmanagementDbContext>();
            var connectionString = configuration.GetConnectionString("TaskmanagementConnectionString");

            builder.UseNpgsql(connectionString);

            return new TaskmanagementDbContext(builder.Options);
        }
    }
}
