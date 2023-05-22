using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Task.CQRS.Commands;
using Taskmanagement.Application.Features.Task.DTOs.Validators;
using Taskmanagement.Application.Responses;
using MediatR;
using Taskmanagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Application.Features.Task.DTOs;

namespace Taskmanagement.Application.Features.Task.CQRS.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<CreateTaskDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<CreateTaskDto>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<CreateTaskDto>();
            var validator = new CreateTaskDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateTaskDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Task = _mapper.Map<Task>(request.CreateTaskDto);

                Task = await _unitOfWork.TaskRepository.Add(Task);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = _mapper.Map<CreateTaskDto>(Task);
            }

            return response;
        }
    }
}
