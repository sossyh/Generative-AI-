using Taskmanagement.Application.Features.checklist.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Features.checklist.DTOs.Validators
{
    public class CreateChecklistDtoValidator : AbstractValidator<CreateChecklistDto>
    {
        public CreateChecklistDtoValidator()
        {
           
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }

}
