using System;
using Taskmanagement.Domain.Common;

namespace Taskmanagement.Domain.Checklists
{
    public class Checklist
    {

        public string Title { get; set; }
        public int AssociatedTaskId { get; set; }
        public bool Status { get; set; }
        public Task AssociatedTask { get; set; } // Navigation property for the associated task
    }
}