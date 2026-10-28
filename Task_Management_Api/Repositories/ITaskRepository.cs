using Task_Management_Api.Models;

namespace Task_Management_Api.Repositories
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAll();
        TaskItem? GetById(int id);
        TaskItem Add(TaskItem task);
        void Update(TaskItem task);
        void Delete(TaskItem task);

    }
}
