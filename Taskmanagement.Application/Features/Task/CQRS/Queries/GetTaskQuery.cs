using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.Task.CQRS.Queries;

public class GetTaskListQuery : IRequest<Result<List<TaskListDto>>>
{
}