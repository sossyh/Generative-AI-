using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Checklist.CQRS.Queries;
using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.Checklist.CQRS.Handlers;

public class GetChecklistListQueryHandler : IRequestHandler<GetChecklistListQuery, Result<List<ChecklistListDto>>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetChecklistListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<ChecklistListDto>>> Handle(GetChecklistListQuery request, CancellationToken cancellationToken)
    {
        var Checklist = await _unitOfWork.ChecklistRepository.GetAll();
        var ChecklistList = _mapper.Map<List<ChecklistListDto>>(Checklist);

        return new Result<List<ChecklistListDto>>() { Value = ChecklistList, Message = "Successful", Success = true, };
    }


}