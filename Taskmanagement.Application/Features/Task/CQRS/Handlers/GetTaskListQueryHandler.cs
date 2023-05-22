using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Task.CQRS.Queries;
using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Task.CQRS.Handlers;

public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, Result<List<TagListDto>>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<TaskListDto>>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _unitOfWork.TaskRepository.GetAll();
        var taskList = _mapper.Map<List<TaskListDto>>(tasks);

        return new Result<List<TaskListDto>>() { Value = taskList, Message = "Successful", Success = true, };
    }


}