using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Domain;

namespace Taskmanagement.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
