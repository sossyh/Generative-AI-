using Taskmanagement.Application.Features.Task.CQRS.Handlers;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Features.Task.CQRS.Commands;
using Taskmanagement.Application.Profiles;
using AutoMapper;
using Taskmanagement.Tests.Mocks;
using Shouldly;
using Moq;
using Taskmanagement.Tests.Mocks;
using Xunit;
using Application.Features.Task.CQRS.Handlers;

namespace Taskmanagement.Tests.Task.Command;  

public class DeleteTaskCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private DeleteTaskCommandHandler _handler { get; set; }

       public DeleteTaskCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new DeleteTaskCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task DeleteTaskValid()
       {
       
              DeleteTaskDto deleteTaskDto = new() { Id = 1 };
              
              var result = await _handler.Handle(new DeleteTaskCommand() { DeleteTaskDto =  deleteTaskDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object.TaskRepository.GetAll()).Count.ShouldBe(1);
       }
       
       [Fact]
       public async Task DeleteTaskInvalid()
       {
       
              DeleteTaskDto deleteTaskDto = new() { Id = 100 };
              
              var result = await _handler.Handle(new DeleteTaskCommand() { DeleteTaskDto =  deleteTaskDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object.TaskRepository.GetAll()).Count.ShouldBe(2);
       }
}


