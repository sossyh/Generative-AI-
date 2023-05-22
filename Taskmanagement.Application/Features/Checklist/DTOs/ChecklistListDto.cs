namespace Taskmanagement.Application.Features.Checklist.DTOs;

public class ChecklistListDto
{

        public string Title { get; set; }
        public int AssociatedTaskId { get; set; }
        public bool Status { get; set; }
        public Task AssociatedTask { get; set; }
}