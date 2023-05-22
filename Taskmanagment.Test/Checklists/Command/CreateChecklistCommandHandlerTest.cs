using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Checklist.CQRS.Commands;
using Taskmanagement.Application.Features.Checklist.CQRS.Handlers;
using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Profiles;
using Taskmanagement.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace Taskmanagement.Tests.Checklist.Command;

public class CreateChecklistCommandHandlerTest
{

    
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private CreateChecklistCommandHandler _handler { get; set; }
       

       public CreateChecklistCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new CreateChecklistCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task CreateChecklistValid()
       {
       
              CreateChecklistDto createChecklistDto = new()
              {
                     Id=3,
                Title = "hi",
                AssociatedTaskId = 1,
                Status = true,
              };
              
              var result = await _handler.Handle(new CreateChecklistCommand() {  ChecklistDto = createChecklistDto }, CancellationToken.None);
              
              result.Value?.Content.ShouldBeEquivalentTo(createChecklistDto.Content);
              result.Value?.AssociatedTaskId.ShouldBeEquivalentTo(createChecklistDto.AssociatedTaskId);
              result.Value?.BlogId.ShouldBeEquivalentTo(createChecklistDto.Id);
              
              (await _mockUnitOfWork.Object._ChecklistRepository.GetAll()).Count.ShouldBe(3);
       }
       
       [Fact]
       public async Task CreateChecklistInvalid()
       {
       
              CreateChecklistDto createBlogDto = new()
              {
                     Id=1,
                Title = "hi",
                AssociatedTaskId = 1,
                Status = true,
              };
              
              var result = await _handler.Handle(new CreateChecklistCommand() { ChecklistDto = createBlogDto }, CancellationToken.None);
              
              result.Value.ShouldBe(null);
       }
}
