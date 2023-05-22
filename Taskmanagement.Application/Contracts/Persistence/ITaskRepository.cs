using System;
using System.Collections.Generic;
using System.Text;
using Taskmanagement.Domain;

namespace Taskmanagement.Application.Contracts.Persistence
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        
    }
}