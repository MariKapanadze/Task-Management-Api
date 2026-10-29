using Microsoft.EntityFrameworkCore;
using Task_Management_Api.Models;

namespace Task_Management_Api.Data;

public class PostgreSqlTaskManagementDbContext : DbContext
{
    public PostgreSqlTaskManagementDbContext(
        DbContextOptions<PostgreSqlTaskManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> Tasks { get; set; }
}
