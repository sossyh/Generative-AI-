using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Exceptions;
using Taskmanagement.Application.Features.User.CQRS.Commands;
using Taskmanagement.Application.Features.User.CQRS.Handlers;
using Taskmanagement.Application.Features.User.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Application.Responses;
using Taskmanagement.Application.Features.User.DTOs;
using FluentValidation;

namespace Taskmanagement.Application.Features.User.CQRS.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UpdateUserDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateUserDto?>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var response = new Result<UpdateUserDto?>();
        var validator = new UpdateUserDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.UpdateUserDto);

        if (validationResult.IsValid == true){
            var User = await _unitOfWork.UserRepository.Get(request.UpdateUserDto.Id);
            _mapper.Map(request.UpdateUserDto, User);

            await _unitOfWork.UserRepository.Update(User);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Message = "Updation Successful!";
                    // response.Value = new Unit();
                    response.Value = _mapper.Map<UpdateUserDto>(User);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Updation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }
        }
        else{

            response.Success = false;
            response.Message = "Updation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        }



        return response;
    }
}