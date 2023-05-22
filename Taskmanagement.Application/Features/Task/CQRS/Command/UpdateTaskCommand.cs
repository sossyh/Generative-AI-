using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.Task.CQRS.Commands;

public class UpdateTaskCommand : IRequest<Result<UpdateTaskDto?>>
{
    public UpdateTaskDto UpdateTaskDto { get; set; }
}