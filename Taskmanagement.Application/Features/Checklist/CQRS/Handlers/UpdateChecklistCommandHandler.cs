using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Exceptions;
using Taskmanagement.Application.Features.Checklist.CQRS.Commands;
using Taskmanagement.Application.Features.Checklist.CQRS.Handlers;
using Taskmanagement.Application.Features.Checklist.DTOs.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Application.Responses;
using Taskmanagement.Application.Features.Checklist.DTOs;
using FluentValidation;

namespace Taskmanagement.Application.Features.Checklist.CQRS.Handlers;

public class UpdateChecklistCommandHandler : IRequestHandler<UpdateChecklistCommand, Result<UpdateChecklistDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateChecklistCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateChecklistDto?>> Handle(UpdateChecklistCommand request, CancellationToken cancellationToken)
    {

        var response = new Result<UpdateChecklistDto?>();
        var validator = new UpdateChecklistDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.UpdateChecklistDto);

        if (validationResult.IsValid == true){
            var Checklist = await _unitOfWork.ChecklistRepository.Get(request.UpdateChecklistDto.Id);
            _mapper.Map(request.UpdateChecklistDto, Checklist);

            await _unitOfWork.ChecklistRepository.Update(Checklist);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Message = "Updation Successful!";
                    // response.Value = new Unit();
                    response.Value = _mapper.Map<UpdateChecklistDto>(Checklist);
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