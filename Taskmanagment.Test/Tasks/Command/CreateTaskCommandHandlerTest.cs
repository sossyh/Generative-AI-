using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Features.Task.CQRS.Commands;
using Taskmanagement.Application.Features.Task.CQRS.Handlers;
using Taskmanagement.Application.Profiles;
using AutoMapper;
using Taskmanagement.Tests.Mocks;
using Shouldly;
using Moq;
using Xunit;
using Taskmanagement.Tests.Mocks;

namespace Taskmanagement.Tests.Task.Command;

public class CreateTaskCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private CreateTaskCommandHandler _handler { get; set; }
       

       public CreateTaskCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new CreateTaskCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task CreateTaskValid()
       {
       
              CreateTaskDto createTaskDto = new()
              {
                     Owner = "Abebe",
                     Title = "Title of Task",
                     Description = "Body of Task",
                     Status = true,
                     
              };
              
              var result = await _handler.Handle(new CreateTaskCommand() { CreateTaskDto = createTaskDto }, CancellationToken.None);
              
              result.Value.Description.ShouldBeEquivalentTo(createTaskDto.Description);
              result.Value.Title.ShouldBeEquivalentTo(createTaskDto.Title);
              
              (await _mockUnitOfWork.Object.TaskRepository.GetAll()).Count.ShouldBe(3);
       }
       
       [Fact]
       public async Task CreateTaskInvalid()
       {
       
              CreateTaskDto createTaskDto = new()
              {
                     Owner = "",
                     Title = "", 
                     Description = "Description of the Task",
                     Status = true,
                   
              };
              
              var result = await _handler.Handle(new CreateTaskCommand() { CreateTaskDto = createTaskDto }, CancellationToken.None);
              
              result.Value.ShouldBe(null);
       }
}


