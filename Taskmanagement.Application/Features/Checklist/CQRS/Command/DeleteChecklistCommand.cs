using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.checklist.CQRS.Commands;

public class DeleteChecklistCommand: IRequest<Result<Unit>>
{
    public DeleteChecklistDto DeleteChecklistDto;
}