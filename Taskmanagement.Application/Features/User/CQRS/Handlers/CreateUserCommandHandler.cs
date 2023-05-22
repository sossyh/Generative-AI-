using AutoMapper;
using Taskmanagement.Application.Persistence;
using Taskmanagement.Application.Features.User.CQRS.Commands;
using Taskmanagement.Application.Features.User.DTOs.Validators;
using Taskmanagement.Application.Responses;
using MediatR;
using Taskmanagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Application.Features.User.DTOs;

namespace Taskmanagement.Application.Features.User.CQRS.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<CreateUserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<CreateUserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<CreateUserDto>();
            var validator = new CreateUserDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateUserDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var User = _mapper.Map<User>(request.CreateUSerDto);

                User = await _unitOfWork.UserRepository.Add(User);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = _mapper.Map<CreateUserDto>(User);
            }

            return response;
        }
    }
}
