
namespace Task_Management_Api.DTOs
{
    public class TaskResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Assignee { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }

        public Task_Management_Api.Models.TaskStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
