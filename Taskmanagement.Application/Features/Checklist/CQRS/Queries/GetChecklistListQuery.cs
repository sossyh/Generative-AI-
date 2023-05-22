using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.Checklist.CQRS.Queries;

public class GetChecklistListQuery : IRequest<Result<List<ChecklistListDto>>>
{
}