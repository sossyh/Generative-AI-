using Taskmanagement.Application.Features.Checklist.CQRS.Commands;
using Taskmanagement.Application.Features.Checklist.CQRS.Queries;
using Taskmanagement.Application.Features.Checklist.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Taskmanagement.API.Controllers;

 
[ApiController]
[Route("api/[controller]")]
public class ChecklistController : ControllerBase
{
    private readonly IMediator _mediator;
    public ChecklistController(IMediator mediatR)
    {
        _mediator = mediatR;     
    }

    
        [HttpGet]
        public async Task<ActionResult<List<ChecklistDto>>> Get()
        {
            var indices = await _mediator.Send(new GetChecklistListQuery());
            return Ok(indices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChecklistDto>> Get(int id)
        {
            var indices = await _mediator.Send(new GetChecklistDetailQuery { Id = id });
            return Ok(indices);
        }


    [HttpPost]
      public async Task<ActionResult> Post([FromBody] CreateChecklistDto checklistDto){
        var response = await _mediator.Send(new CreateChecklistCommand{ChecklistDto = checklistDto});
        return Ok(response);   
    }

     [HttpPut]
      public async Task<ActionResult> Put([FromBody] UpdateChecklistDto checklistDto){

         await _mediator.Send(new UpdateChecklistCommand{ChecklistDto = checklistDto});
        return NoContent(); 
    }

     [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(DeleteChecklistDto checklistDto){
         await _mediator.Send(new DeleteChecklistCommand{ ChecklistDto = checklistDto});
        return NoContent(); 
    }
}

