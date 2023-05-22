using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.User.CQRS.Queries;
using Taskmanagement.Application.Features.User.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.User.CQRS.Handlers;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, Result<List<UserListDto>>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<UserListDto>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetAll();
        var userList = _mapper.Map<List<UserListDto>>(users);

        return new Result<List<UserListDto>>() { Value = userList, Message = "Successful", Success = true, };
    }


}