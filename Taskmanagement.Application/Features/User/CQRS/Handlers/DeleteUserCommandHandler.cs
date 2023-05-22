using System.ComponentModel.DataAnnotations;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.User.DTOs.Validators;
using Taskmanagement.Application.Features.User.CQRS.Commands;
using AutoMapper;
using Taskmanagement.Application.Exceptions;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Application.Features.User.CQRS.Handlers;

public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommand, Result<Unit>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var response = new Result<Unit>();
        
        var validator = new DeleteUserDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.DeleteUserDto);
       
        if (validationResult.IsValid == true){
            var User = await _unitOfWork.UserRepository.Get(request.DeleteUserDto.Id);
            await _unitOfWork.UserRepository.Delete(User);
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
