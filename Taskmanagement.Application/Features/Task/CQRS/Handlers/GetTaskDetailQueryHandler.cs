using Taskmanagement.Application.Contracts.Persistence;
using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Features.Task.CQRS.Queries;
using AutoMapper;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.Task.CQRS.Queries;

public class GetTaskDetailsQueryHandler: IRequestHandler<GetTaskDetailsQuery, Result<TaskDetailsDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTaskDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<TaskDetailsDto?>> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
    {
        var task = await _unitOfWork.TaskRepository.Get(request.Id);
        var TaskDto = _mapper.Map<TaskDetailsDto>(task);
        return new Result<TaskDetailsDto?>() { Value = TaskDto, Message = "Successful", Success = true, };
    }
}   