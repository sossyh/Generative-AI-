using Taskmanagement.Application.Persistence;
using Taskmanagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TaskmanagementDbContext _dbContext;

        public UserRepository(TaskmanagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
