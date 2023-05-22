using Taskmanagement.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Taskmanagement.Application.Features.Checklist.DTOs
{
    public class ChecklistDto : BaseDto
    {
        public string Title { get; set; }
        public int AssociatedTaskId { get; set; }
        public bool Status { get; set; }
        public Task AssociatedTask { get; set; }
    }
}
