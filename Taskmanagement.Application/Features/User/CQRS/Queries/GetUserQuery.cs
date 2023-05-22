using Taskmanagement.Application.Features.User.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.User.CQRS.Queries;

public class GetUserListQuery : IRequest<Result<List<UserListDto>>>
{
}