using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.User.DTOs;
using Taskmanagement.Application.Features.User.CQRS.Queries;
using AutoMapper;
using Taskmanagement.Application.Responses;
using MediatR;

namespace Taskmanagement.Application.Features.User.CQRS.Queries;

public class GetUserDetailsQueryHandler: IRequestHandler<GetUserDetailsQuery, Result<UserDetailsDto?>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UserDetailsDto?>> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var User = await _unitOfWork.Repository.Get(request.Id);
        var UserDto = _mapper.Map<UserDetailsDto>(User);
        return new Result<UserDetailsDto?>() { Value = UserDto, Message = "Successful", Success = true, };
    }
}   