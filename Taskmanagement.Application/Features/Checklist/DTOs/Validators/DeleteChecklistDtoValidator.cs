using Taskmanagement.Application.Persistence;
using FluentValidation;

namespace Taskmanagement.Application.Features.Checklist.DTOs.Validators;

public class DeleteChecklistDtoValidator: AbstractValidator<DeleteChecklistDto>
{
    private IChecklistRepository _ChecklistRepository;

    public DeleteChecklistDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork.ChecklistRepository.Exists(id)).WithMessage($"Checklist not found");
    }
}