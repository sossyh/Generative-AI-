using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.Task.CQRS.Commands;

public class DeleteTaskCommand: IRequest<Result<Unit>>
{
    public DeleteTaskDto DeleteTaskDto;
}