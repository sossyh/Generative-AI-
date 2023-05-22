using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.Tags.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Features.Checklist.DTOs.Validators
{
    public class UpdateChecklistDtoValidator : AbstractValidator<UpdateChecklistDto>
    {
        public UpdateChecklistDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Id)
           .GreaterThan(0)
           .MustAsync(async (id, token) => await unitOfWork.ChecklistRepository.Exists(id)).WithMessage($"Checklist not found");
        } 
    }
}
