using Microsoft.EntityFrameworkCore;
using Task_Management_Api.Models;
using TaskStatus = Task_Management_Api.Models.TaskStatus;

namespace Task_Management_Api.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(
            TaskManagementDbContext context)
        {
            if (!await context.Tasks.AnyAsync())
            {
                var tasks = new List<TaskItem>
                {
                    new TaskItem
                    {
                        Title = "Create login page",
                        Description = "Build the login page UI",
                        Assignee = "Alice",
                        Status = TaskStatus.TO_DO
                    },
                    new TaskItem
                    {
                        Title = "Implement authentication",
                        Description = "Add user authentication",
                        Assignee = "Bob",
                        Status = TaskStatus.IN_PROGRESS
                    },
                    new TaskItem
                    {
                        Title = "Fix navigation bug",
                        Description = "Fix the menu navigation issue",
                        Assignee = "Alice",
                        Status = TaskStatus.DONE
                    },
                    new TaskItem
                    {
                        Title = "Create database schema",
                        Description = "Design the database tables",
                        Assignee = "Charlie",
                        Status = TaskStatus.DONE
                    },
                    new TaskItem
                    {
                        Title = "Write unit tests",
                        Description = "Test the task service",
                        Assignee = "Bob",
                        Status = TaskStatus.TO_DO
                    },
                    new TaskItem
                    {
                        Title = "Update API documentation",
                        Description = "Document all API endpoints",
                        Assignee = "Diana",
                        Status = TaskStatus.IN_PROGRESS
                    },
                    new TaskItem
                    {
                        Title = "Add task filtering",
                        Description = "Filter tasks by status and assignee",
                        Assignee = "Charlie",
                        Status = TaskStatus.DONE
                    },
                    new TaskItem
                    {
                        Title = "Improve error handling",
                        Description = "Add centralized exception handling",
                        Assignee = "Diana",
                        Status = TaskStatus.TO_DO
                    },
                    new TaskItem
                    {
                        Title = "Design dashboard",
                        Description = "Create the task dashboard",
                        Assignee = "Alice",
                        Status = TaskStatus.IN_PROGRESS
                    },
                    new TaskItem
                    {
                        Title = "Review pull request",
                        Description = "Review recent code changes",
                        Assignee = "Bob",
                        Status = TaskStatus.DONE
                    }
                };

                await context.Tasks.AddRangeAsync(tasks);
                await context.SaveChangesAsync();
            }

            var adminPassword = Environment.GetEnvironmentVariable("ADMIN_SEED_PASSWORD");

            if (!string.IsNullOrWhiteSpace(adminPassword))
            {
                var adminExists = await context.Users
                    .AnyAsync(user => user.Username == "admin");

                if (!adminExists)
                {
                    var admin = new AppUser
                    {
                        Username = "admin",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminPassword),
                        Role = "ADMIN",
                        Active = true,
                        CreatedAt = DateTime.UtcNow
                    };

                    context.Users.Add(admin);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
