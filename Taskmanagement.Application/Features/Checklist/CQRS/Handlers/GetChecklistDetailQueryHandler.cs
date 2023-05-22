using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Features.Checklist.CQRS.Queries;
using AutoMapper;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.Checklist.CQRS.Queries;

public class GetChecklistDetailsQueryHandler: IRequestHandler<GetChecklistDetailsQuery, Result<ChecklistDetailsDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetChecklistDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ChecklistDetailsDto?>> Handle(GetChecklistDetailsQuery request, CancellationToken cancellationToken)
    {
        var Checklist = await _unitOfWork.ChecklistRepository.Get(request.Id);
        var ChecklistDto = _mapper.Map<ChecklistDetailsDto>(Checklist);
        return new Result<ChecklistDetailsDto?>() { Value =  ChecklistDto, Message = "Successful", Success = true, };
    }
}   