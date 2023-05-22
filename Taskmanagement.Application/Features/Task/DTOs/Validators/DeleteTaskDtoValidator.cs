using Taskmanagement.Application.Persistence;
using FluentValidation;

namespace Taskmanagement.Application.Features.Task.DTOs.Validators;

public class DeleteTaskDtoValidator: AbstractValidator<DeleteTaskDto>
{
    private ITaskRepository _taskRepository;

    public DeleteTaskDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async (id, token) => await unitOfWork.TaskRepository.Exists(id)).WithMessage($"Task not found");
    }
}