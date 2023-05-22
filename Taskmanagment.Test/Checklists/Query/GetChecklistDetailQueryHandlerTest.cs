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

public class GetChecklistDetailQueryHandlerTest
{

    
    private IMapper _mapper { get; set; }
    private Mock<IUnitOfWork> _mockUnitOfWork{ get; set; }  
    private GetChecklistDetailQueryHandler _handler { get; set; }

    public GetChecklistDetailQueryHandlerTest()
    { 
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
        _mapper = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        }).CreateMapper();

        _handler = new GetChecklistDetailQueryHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task GetTaskDetailsValid()
    {
        var result = await _handler.Handle(new GetChecklistDetailQuery() { Id = 1}, CancellationToken.None);
        result.ShouldNotBe(null);
    }
       
    [Fact]
    public async Task GetTaskDetailsInvalid()
    {
        var result = await _handler.Handle(new GetChecklistDetailQuery() { Id = 100}, CancellationToken.None);
        result.Value.ShouldBe(null);
    }
}




