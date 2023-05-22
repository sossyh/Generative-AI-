using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Features.Checklist.CQRS.Handlers;
using Taskmanagement.Application.Features.Checklist.CQRS.Commands;
using Taskmanagement.Application.Profiles;
using AutoMapper;
using Taskmanagement.Tests.Mocks;
using Shouldly;
using Moq;
using Xunit;
using Taskmanagement.Tests.Mocks;
using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Features.Checklist.CQRS.Commands;
using Taskmanagement.Application.Features.Checklist.CQRS.Handlers;

namespace Taskmanagement.Tests.Checklist.Command;

public class UpdateChecklistCommandHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private UpdateChecklistCommandHandler _handler { get; set; }


    public UpdateChecklistCommandHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new UpdateChecklistCommandHandler(_mockUnitOfWork.Object, _mapper);
    }


    [Fact]
    public async Task UpdateChecklistValid()
    {

        UpdateChecklistDto checklistDto = new()
        {
            Id=1,
            Content = "This is new checklist",
            
                   };

        var result = await _handler.Handle(new UpdateChecklistCommand() {ChecklistDto  = checklistDto }, CancellationToken.None);

        var updatedChecklist = await _mockUnitOfWork.Object._ChecklistRepository.Get(1);

        updatedChecklist.Content.ShouldBe(checklistDto.Content);
       

        (await _mockUnitOfWork.Object._ChecklistRepository.GetAll()).Count.ShouldBe(2);
    }
}
