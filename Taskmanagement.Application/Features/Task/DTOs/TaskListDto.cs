namespace Taskmanagement.Application.Features.Task.DTOs;

public class TaskListDto
{

    public string Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
}