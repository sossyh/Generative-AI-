namespace Taskmanagement.Application.Features.Checklist.DTOs;

public class UpdateChecklistDto
{

        public int Id { get; set; }
        public string Title { get; set; }
        public int AssociatedTaskId { get; set; }
        public bool Status { get; set; }
        public Task AssociatedTask { get; set; }
    
}