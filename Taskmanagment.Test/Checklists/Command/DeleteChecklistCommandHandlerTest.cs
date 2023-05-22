using Application.Features.Checklist.CQRS.Handlers;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Features.Checklist.CQRS.Commands;
using Taskmanagement.Application.Profiles;
using AutoMapper;
using Taskmanagement.Tests.Mocks;
using Shouldly;
using Moq;
using Taskmanagement.Tests.Mocks;
using Xunit;
using Taskmanagement.Application.Features.Checklist.CQRS.Handlers;
using Taskmanagement.Application.Features.Checklist.CQRS.Commands;
using Taskmanagement.Application.Features.Checklist.DTOs;



namespace Taskmanagement.Tests.Checklist.Command;  

public class DeleteChecklistCommandHandlerTest
{
       private IMapper _mapper { get; set; }
       private Mock<IUnitOfWork> _mockUnitOfWork { get; set; }
       private DeleteChecklistCommandHandler _handler { get; set; }

       public DeleteChecklistCommandHandlerTest()
       {
              _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
              
              _mapper = new MapperConfiguration(c =>
              {
                     c.AddProfile<MappingProfile>();
              }).CreateMapper();

              _handler = new DeleteChecklistCommandHandler(_mockUnitOfWork.Object, _mapper);
       }
       
       
       [Fact]
       public async Task DeleteChecklistValid()
       {
       
              DeleteChecklistDto deleteChecklistDto = new() { Id = 1};
              
               var result = await _handler.Handle(new DeleteChecklistCommand() {  ChecklistDto =  deleteChecklistDto}, CancellationToken.None);
               
              
              (await _mockUnitOfWork.Object._ChecklistRepository.GetAll()).Count.ShouldBe(1);
       }
       
       [Fact]
       public async Task DeleteChecklistInvalid()
       {
                
               DeleteChecklistDto deleteChecklistDto = new() { Id = 2 };
              
              var result = await _handler.Handle(new DeleteChecklistCommand() { ChecklistDto =  deleteChecklistDto}, CancellationToken.None);
              
              (await _mockUnitOfWork.Object._ChecklistRepository.GetAll()).Count.ShouldBe(1);
       }
}


