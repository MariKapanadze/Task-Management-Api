namespace Task_Management_Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Assignee {  get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.TO_DO;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
