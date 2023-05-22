using Taskmanagement.Application.Contracts.Persistence;
using Taskmanagement.Application.Features.User.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Features.User.DTOs.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Id)
           .GreaterThan(0)
           .MustAsync(async (id, token) => await unitOfWork.UserRepository.Exists(id)).WithMessage($"User not found");
        } 
    }
}
