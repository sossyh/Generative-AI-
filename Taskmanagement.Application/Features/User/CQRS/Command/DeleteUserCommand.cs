using Taskmanagement.Application.Features.User.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.User.CQRS.Commands;

public class DeleteUserCommand: IRequest<Result<Unit>>
{
    public DeleteUserDto DeleteUserDto;
}