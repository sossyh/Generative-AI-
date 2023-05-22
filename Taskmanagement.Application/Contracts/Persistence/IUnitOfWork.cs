using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository _UserRepository { get; }
        IChecklistRepository _ChecklistRepository { get; }
        ITaskRepository TaskRepository {get;}

        
        Task <int> Save();

    }
}
