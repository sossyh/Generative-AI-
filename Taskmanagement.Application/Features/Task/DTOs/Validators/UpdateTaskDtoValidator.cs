using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Task.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Features.Task.DTOs.Validators
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskDto>
    {
        public UpdateTaskDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Id)
           .GreaterThan(0)
           .MustAsync(async (id, token) => await unitOfWork.TaskRepository.Exists(id)).WithMessage($"Task not found");
        } 
    }
}
