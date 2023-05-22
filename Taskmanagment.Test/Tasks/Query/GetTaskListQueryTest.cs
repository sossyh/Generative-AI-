using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Task.CQRS.Handlers;
using Taskmanagement.Application.Features.Task.CQRS.Queries;
using Taskmanagement.Application.Profiles;
using AutoMapper;
using Taskmanagement.Tests.Mocks;
using Shouldly;
using Moq;
using Taskmanagement.Tests.Mocks;
using Xunit;

namespace Taskmanagement.Tests.Task.Query;

public class GetTaskListQueryHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private GetTaskListQueryHandler _handler { get; set; }

    public GetTaskListQueryHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetTaskistQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetTaskListValid()
    {
        var result = await _handler.Handle(new GetTaskListQuery(), CancellationToken.None);
        result.ShouldNotBe(null);
    }

    [Fact]
    public async Task GetTaskListInvalid()
    {
        var result = await _handler.Handle(new GetTaskListQuery(), CancellationToken.None);
        result.Value.Count.ShouldNotBe(1);
    }
}
