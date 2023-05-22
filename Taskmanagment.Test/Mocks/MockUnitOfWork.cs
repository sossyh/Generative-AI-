using Taskmanagement.Application.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Tests.Mocks;

namespace Taskmanagement.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockUserRepo = MockUserRepository.GetUserRepository();
            var mockChecklistRepo = MockChecklistRepository.GetChecklistRepository();
            var mockTaskRepo = MockTaskRepository.GetTaskRepository();
            mockUow.Setup(r => r.TaskRepository).Returns(mockTaskRepo.Object);
                        
            return mockUow;
        }
    }
}

