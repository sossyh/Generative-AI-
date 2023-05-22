using Taskmanagement.Application.Features.Task.CQRS.Commands;
using Taskmanagement.Application.Features.Task.CQRS.Queries;
using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taskmanagement.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TaskController :   BaseController
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [HttpGet]
    public async Task<ActionResult<List<TaskListDto>>> Get()
    {
        return HandleResult(await _mediator.Send(new GetTaskListQuery()));
    }


         [HttpGet("{id:int}")]
    public async Task<ActionResult> Get(int id)
    {
        return HandleResult(await _mediator.Send(new GetTaskDetailsQuery { Id = id }));
    }

        [HttpPost]
        public async Task<ActionResult<Result<CreateTaskDto>>> Post([FromBody] CreateTaskDto createTaskDto)
        {
            var command = new CreateTaskCommand { CreateTaskDto = createTaskDto };
            var repsonse = await _mediator.Send(command);
            return HandleResult(repsonse);
        }

        [HttpPut]
    public async Task<ActionResult> UpdateTask([FromBody] UpdateTaskDto updateTaskDto)
    {
        return HandleResult(await _mediator.Send(new UpdateTaskCommand() { UpdateTaskDto = updateTaskDto }));
    }

       [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        return HandleResult(
            await _mediator.Send(new DeleteTaskCommand { DeleteTaskDto = new DeleteTaskDto { Id = id } }));
    }
    }
}
