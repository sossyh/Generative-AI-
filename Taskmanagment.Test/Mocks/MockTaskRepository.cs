using Taskmanagement.Application.Persistence;
using Moq;

namespace Taskmanagement.Tests.Mocks;

public static class MockTaskRepository
{
    public static Mock<ITaskRepository> GetTaskRepository()
    {
        var tasks = new List<Taskmanagement.Domain.Tasks>
        {
            new ()
            {
                Id=1,
                Owner= "Abebe",
                Title = "Title of Task 1",
                Description = "Description of Task 1",

            },
            
            new ()
            {
                Id=2,
                Owner="Kebede",
                Title = "Title of Task 2",
                Description = "Description of Task 2",
            }
        };

        var mockRepo = new Mock<ITaskRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(tasks);
        
        mockRepo.Setup(r => r.Add(It.IsAny<Taskmanagement.Domain.Tasks>())).ReturnsAsync((Taskmanagement.Domain.task task) =>
        {
            task.Id = Tasks.Count() + 1;
            Tasks.Add(task);
            return task; 
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Domain.Tasks>())).Callback((Domain.Tasks task) =>
        {
            var newtasks = Tasks.Where((r) => r.Id != task.Id);
            Tasks = newtasks.ToList();
            Tasks.Add(task);
        });
        
        mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Tasks>())).Callback((Domain.Tasks task) =>
        {
            if (tasks.Exists(b => b.Id == task.Id))
                Tasks.Remove(Tasks.Find(b => b.Id == task.Id)!);
        });

        mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var rate = Tasks.FirstOrDefault((r) => r.Id == id);
            return rate != null;
        });
        
        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return Tasks.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}