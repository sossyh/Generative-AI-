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

public class UpdateTaskCommandHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private UpdateTaskCommandHandler _handler { get; set; }


    public UpdateTaskCommandHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new UpdateTaskCommandHandler(_mockUnitOfWork.Object, _mapper);
    }


    [Fact]
    public async Task UpdateTaskValid()
    {

        UpdateTaskDto updateTaskDto = new()
        {
            Id = 1,
            Owner = "Abebe",
            Title = "Title of the updated Task",
            Description = "Description of the updated Task",
        
        };

        var result = await _handler.Handle(new UpdateTaskCommand() { UpdateTaskDto = updateTaskDto }, CancellationToken.None);

        var UpdatedTask = await _mockUnitOfWork.Object.TaskRepository.Get(1);

        UpdatedTask.Description.ShouldBe(updateTaskDto.Description);
        UpdatedTask.Title.ShouldBe(updateTaskDto.Title);

        (await _mockUnitOfWork.Object.TaskRepository.GetAll()).Count.ShouldBe(2);
    }
}
