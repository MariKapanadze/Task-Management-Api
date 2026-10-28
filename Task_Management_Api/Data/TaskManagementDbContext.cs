using Microsoft.EntityFrameworkCore;
using Task_Management_Api.Models;

namespace Task_Management_Api.Data
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(
            DbContextOptions<TaskManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
