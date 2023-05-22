using System;
using System.Collections.Generic;
using System.Text;
using Taskmanagement.Domain;

namespace Taskmanagement.Application.Persistence
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        
    }
}