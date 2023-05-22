using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Checklist.CQRS.Handlers;
using Taskmanagement.Application.Features.Checklist.CQRS.Queries;
using Taskmanagement.Application.Profiles;
using Taskmanagement.Tests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace Taskmanagement.Tests.Checklist.Query;

public class GetChecklistListQueryHandlerTest
{

    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
    private GetChecklistListQueryHandler _handler { get; set; }

    public GetChecklistListQueryHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetChecklistListQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetChecklistListValid()
    {
        var result = await _handler.Handle(new GetChecklistListQuery(), CancellationToken.None);
        result.ShouldNotBe(null);
    }

    [Fact]
    public async Task GetChecklistListInvalid()
    {
        var result = await _handler.Handle(new GetChecklistListQuery(), CancellationToken.None);
        result.Value?.Count.ShouldNotBe(1);
    }
}
