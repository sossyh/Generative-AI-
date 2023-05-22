using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IChecklistRepository _ChecklistRepository { get; }
        IUserRepository _UserRepository { get; }
        
        ITaskRepository _TaskRepository { get; }

        Task <int> Save();

    }
}
