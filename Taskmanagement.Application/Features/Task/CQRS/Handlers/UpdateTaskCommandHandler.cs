using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Exceptions;
using Taskmanagement.Application.Features.Task.CQRS.Commands;
using Taskmanagement.Application.Features.Task.CQRS.Handlers;
using Taskmanagement.Application.Features.Task.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Application.Responses;
using Taskmanagement.Application.Features.Task.DTOs;
using FluentValidation;

namespace Taskmanagement.Application.Features.Task.CQRS.Handlers;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Result<UpdateTaskDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateTaskDto?>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {

        var response = new Result<UpdateTaskDto?>();
        var validator = new UpdateTaskDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.UpdateTaskDto);

        if (validationResult.IsValid == true){
            var task = await _unitOfWork.TaskRepository.Get(request.UpdateTaskDto.Id);
            _mapper.Map(request.UpdateTaskDto, task);

            await _unitOfWork.TaskRepository.Update(task);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Message = "Updation Successful!";
                    // response.Value = new Unit();
                    response.Value = _mapper.Map<UpdateTaskDto>(task);
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