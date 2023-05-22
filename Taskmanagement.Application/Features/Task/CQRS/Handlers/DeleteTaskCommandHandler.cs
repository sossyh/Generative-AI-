using System.ComponentModel.DataAnnotations;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Task.DTOs.Validators;
using Taskmanagement.Application.Features.Task.CQRS.Commands;
using AutoMapper;
using Taskmanagement.Application.Exceptions;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Application.Features.Task.CQRS.Handlers;

public class DeleteTaskCommandHandler: IRequestHandler<DeleteTaskCommand, Result<Unit>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var response = new Result<Unit>();
        
        var validator = new DeleteTaskDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.DeleteTaskDto);
       
        if (validationResult.IsValid == true){
            var task = await _unitOfWork.TaskRepository.Get(request.DeleteTaskDto.Id);
            await _unitOfWork.TaskRepository.Delete(task);
            if (await _unitOfWork.Save() > 0)
            {
                
                response.Message = "Deletion Successful!";
                response.Value = new Unit();
            }
            else
            {
                response.Success = false;
                response.Message = "Deletion Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
        }else{
            response.Success = false;
            response.Message = "Deletion Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        
        return response;
    }
}
