using Microsoft.EntityFrameworkCore;
using Task_Management_Api.Data;
using Task_Management_Api.Models;

namespace Task_Management_Api.Repositories
{
    public class EfTaskRepository : ITaskRepository
    {
        private readonly TaskManagementDbContext _context;

        public EfTaskRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public List<TaskItem> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public TaskItem? GetById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public TaskItem Add(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return task;
        }

        public void Update(TaskItem task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void Delete(TaskItem task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
