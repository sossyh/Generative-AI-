using Taskmanagement.Application.Persistence;
using Moq;

namespace Taskmanagement.Tests.Mocks;

public class MockChecklistRepository
{

     public static Mock<IChecklistRepository> GetChecklistRepository()
    {
        var checklists = new List<Taskmanagement.Domain.Checklists>
        {
            new ()
            {
                Id=1,
                Title = "hi",
                AssociatedTaskId = 1,
                Status = true,
            },
            
            new ()
            {
                Id=2,
                Title = "hello",
                AssociatedTaskId  = 2,
                status = false,
            }
        };

         var mockRepo = new Mock<IChecklistRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(chekclists);
        
        mockRepo.Setup(r => r.Add(It.IsAny<Taskmanagement.Domain.Checklists>())).ReturnsAsync((Taskmanagement.Domain.Checklists checklist) =>
        {
            checklist.Id = checklsits.Count() + 1;
            checklists.Add(checklist);
            return checklist; 
        });

        mockRepo.Setup(r => r.Update(It.IsAny<Domain.Checklists>())).Callback((Domain.Checklists checklist) =>
        {
            var newChecklists = checklists.Where((r) => r.Id != checklist.Id);
            checklists = newChecklsits.ToList();
            checklists.Add(checklist);
        });
        
        mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Checklists>())).Callback((Domain.Checklists checklist) =>
        
        {
            if (checklists.Exists(b => b.Id == checklist.Id))
                checklists.Remove(checklists.Find(b => b.Id == checklist.Id)!);
        });

         mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
        {
            var checklist = checklists.FirstOrDefault((r) => r.Id == id);
            return checklist != null;
        });

        
        mockRepo.Setup(r => r.Get(It.IsAny<int>()))!.ReturnsAsync((int id) =>
        {
            return checklists.FirstOrDefault((r) => r.Id == id);
        });

        return mockRepo;
    }
}