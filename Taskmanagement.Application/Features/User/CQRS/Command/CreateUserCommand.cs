using Taskmanagement.Application.Features.User.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Features.User.CQRS.Commands
{
    public class CreateUserCommand: IRequest<Result<CreateUserDto>>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}
