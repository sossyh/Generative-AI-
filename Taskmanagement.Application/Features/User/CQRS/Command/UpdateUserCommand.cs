using Taskmanagement.Application.Features.User.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.User.CQRS.Commands;

public class UpdateUserCommand : IRequest<Result<UpdateUserDto?>>
{
    public UpdateUserDto UpdateUserDto { get; set; }
}