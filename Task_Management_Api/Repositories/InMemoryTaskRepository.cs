using Task_Management_Api.Models;

namespace Task_Management_Api.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public List<TaskItem> GetAll()
        {
            return _tasks;
        }
        public TaskItem? GetById(int id)
        {
            return _tasks.FirstOrDefault(task => task.Id == id);
        }
        public TaskItem Add(TaskItem task)
        {
            task.Id = _nextId++;
            task.CreatedAt = DateTime.UtcNow;
            _tasks.Add(task);
            return task;
        }
        public void Update(TaskItem task)
        {
            //nothing at all
        }
        public void Delete(TaskItem task)
        {
            _tasks.Remove(task);
        }
    }
}
