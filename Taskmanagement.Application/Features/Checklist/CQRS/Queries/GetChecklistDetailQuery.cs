using MediatR;
using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Responses;

namespace Taskmanagement.Application.Features.Checklist.CQRS.Queries;

public class GetChecklistDetailsQuery: IRequest<Result<ChecklistDetailsDto?>>
{
    public int Id { get; set; }
}