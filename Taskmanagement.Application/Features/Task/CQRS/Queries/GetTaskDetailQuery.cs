using MediatR;
using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Responses;

namespace Taskmanagement.Application.Features.Task.CQRS.Queries;

public class GetTaskDetailsQuery: IRequest<Result<TaskDetailsDto?>>
{
    public int Id { get; set; }
}