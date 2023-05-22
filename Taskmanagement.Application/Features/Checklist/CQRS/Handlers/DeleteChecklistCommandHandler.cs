using System.ComponentModel.DataAnnotations;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Checklist.DTOs.Validators;
using Taskmanagement.Application.Features.Checklist.CQRS.Commands;
using AutoMapper;
using Taskmanagement.Application.Exceptions;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Application.Features.Checklist.CQRS.Handlers;

public class DeleteChecklistCommandHandler: IRequestHandler<DeleteChecklistCommand, Result<Unit>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteChecklistCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(DeleteChecklistCommand request, CancellationToken cancellationToken)
    {
        var response = new Result<Unit>();
        
        var validator = new DeleteChecklistDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.DeleteChecklistDto);
       
        if (validationResult.IsValid == true){
            var Checklist = await _unitOfWork.ChecklistRepository.Get(request.DeleteChecklistDto.Id);
            await _unitOfWork.ChecklistRepository.Delete(Checklist);
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
