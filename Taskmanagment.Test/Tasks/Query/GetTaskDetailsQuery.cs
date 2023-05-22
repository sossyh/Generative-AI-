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

public class GetTaskDetailsQueryHandlerTest
{
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork{ get; set; }  
    private GetTaskDetailsQueryHandler _handler { get; set; }

    public GetTaskDetailsQueryHandlerTest()
    { 
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetTaskDetailsQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetTaskDetailsValid()
    {
        var result = await _handler.Handle(new GetTaskDetailsQuery() { Id = 2}, CancellationToken.None);
        result.ShouldNotBe(null);
    }
       
    [Fact]
    public async Task GetTaskDetailsInvalid()
    {
        var result = await _handler.Handle(new GetTaskDetailsQuery() { Id = 100}, CancellationToken.None);
        result.Value.ShouldBe(null);
    }
}


