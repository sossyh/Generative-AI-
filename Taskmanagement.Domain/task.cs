using System;
using Taskmanagement.Domain.Common;

namespace Taskmanagement.Domain.Tasks
{
    public class Task
    {
        
        public string Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}