using Taskmanagement.Application.Persistence;
using Taskmanagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Persistence.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        private readonly TaskmanagementDbContext _dbContext;

        public TagRepository(TaskmanagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
