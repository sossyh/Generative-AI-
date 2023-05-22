using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Application.Features.Checklist.CQRS.Commands
{
    public class CreateChecklistCommand: IRequest<Result<CreateChecklistDto>>
    {
        public CreateChecklistDto CreateChecklistDto { get; set; }
    }
}
