using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.checklist.CQRS.Commands;

public class UpdateChecklistCommand : IRequest<Result<UpdateChecklistDto?>>
{
    public UpdateChecklistDto UpdateChecklistDto { get; set; }
}