namespace Task_Management_Api.DTOs
{
    public class CreateTaskRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Assignee {  get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
    }
}
