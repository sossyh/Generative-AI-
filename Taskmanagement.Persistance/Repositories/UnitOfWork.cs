using Taskmanagement.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TaskmanagementDbContext _context;

        
        private ITaskRepository _taskRepository;
        private IChecklistRepository _checklistRepository;
        
        private IUserRepository _userRepository;
    
        public UnitOfWork(TaskmanagementDbContext context)
        {
            _context = context;
        }

        public IUserRepository _UserRepository { 
            get 
            {
                if (_userRepository == null)
                    _userRepository = new _userRepository(_context);
                return _userRepository;
            } 
         }
          public ITaskRepository TaskRepository { 
            get 
            {
                if (_taskRepository == null)
                    _taskRepository = new TaskRepository(_context);
                return _taskRepository; 
            } 
         }

        public IChecklistRepository ChecklistRepository
        {
            get
            {
                if (_checklistRepository == null)
                    _checklistRepository = new ChecklistRepository(_context);
                return _checklistRepository;
            }
        }
         

        

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
