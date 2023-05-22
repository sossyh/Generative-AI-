using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Checklist.CQRS.Commands;
using Taskmanagement.Application.Features.Checklist.DTOs.Validators;
using Taskmanagement.Application.Responses;
using MediatR;
using Taskmanagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Application.Features.Checklist.DTOs;

namespace Taskmanagement.Application.Features.Checklist.CQRS.Handlers
{
    public class CreateChecklistCommandHandler : IRequestHandler<CreateChecklistCommand, Result<CreateChecklistDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateChecklistCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<CreateChecklistDto>> Handle(CreateChecklistCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<CreateChecklistDto>();
            var validator = new CreateChecklistDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateChecklistDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Checklist = _mapper.Map<Checklist>(request.CreateChecklistDto);

                Checklist = await _unitOfWork.ChecklistRepository.Add(Checklist);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = _mapper.Map<CreateChecklistDto>(Checklist);
            }

            return response;
        }
    }
}
