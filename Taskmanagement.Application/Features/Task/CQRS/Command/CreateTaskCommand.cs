using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Features.Task.CQRS.Commands
{
    public class CreateTaskCommand: IRequest<Result<CreateTaskDto>>
    {
        public CreateTaskDto CreateTaskDto { get; set; }
    }
}
