using MediatR;
using Taskmanagement.Application.Features.User.DTOs;
using Taskmanagement.Application.Responses;

namespace Taskmanagement.Application.Features.User.CQRS.Queries;

public class GetUserDetailsQuery: IRequest<Result<UserDetailsDto?>>
{
    public int Id { get; set; }
}