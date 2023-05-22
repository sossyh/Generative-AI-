using Taskmanagement.Application.Persistence;
using FluentValidation;

namespace Taskmanagement.Application.Features.User.DTOs.Validators;

public class DeleteUserDtoValidator: AbstractValidator<DeleteUserDto>
{
    private IUserRepository _UserRepository;

    public DeleteUserDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork.UserRepository.Exists(id)).WithMessage($"User not found");
    }
}