
using Task_Management_Api.Repositories;
using Task_Management_Api.Services;
using Xunit;

namespace Task_Management_Api.Tests
{
    public class TaskServiceTests
    {
        [Fact]
        public void GetAll_WhenNoTasksExist_ReturnsEmptyList()
        {
            // Arrange
            var repository = new InMemoryTaskRepository();
            var service = new TaskService(repository);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.Empty(result);
        }


        [Fact]
        public void Create_WithValidRequest_ReturnsCreatedTask()
        {
            // Arrange
            var repository = new InMemoryTaskRepository();
            var service = new TaskService(repository);

            var request = new Task_Management_Api.DTOs.CreateTaskRequest
            {
                Title = "Learn unit testing",
                Description = "Practice xUnit",
                Assignee = "Mari",
                DueDate = null
            };

            // Act
            var result = service.Create(request);

            // Assert
            Assert.True(result.Id > 0);
            Assert.Equal("Learn unit testing", result.Title);
            Assert.Equal("Mari", result.Assignee);
            Assert.Equal(
                Task_Management_Api.Models.TaskStatus.TO_DO,
                result.Status);
        }


        [Fact]
        public void Create_WithTooShortTitle_ThrowsArgumentException()
        {
            // Arrange
            var repository = new InMemoryTaskRepository();
            var service = new TaskService(repository);

            var request = new Task_Management_Api.DTOs.CreateTaskRequest
            {
                Title = "AB",
                Description = "Testing invalid input",
                Assignee = "Mari",
                DueDate = null
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => service.Create(request));
        }


        [Fact]
        public void GetById_WhenTaskExists_ReturnsCorrectTask()
        {
            // Arrange
            var repository = new InMemoryTaskRepository();
            var service = new TaskService(repository);

            var request = new Task_Management_Api.DTOs.CreateTaskRequest
            {
                Title = "Learn C#",
                Description = "Practice unit testing",
                Assignee = "Mari",
                DueDate = null
            };

            var createdTask = service.Create(request);

            // Act
            var result = service.GetById(createdTask.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdTask.Id, result.Id);
            Assert.Equal("Learn C#", result.Title);
        }


        [Fact]
        public void GetById_WhenTaskDoesNotExist_ReturnsNull()
        {
            // Arrange
            var repository = new InMemoryTaskRepository();
            var service = new TaskService(repository);

            // Act
            var result = service.GetById(999);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public void Update_WhenTaskExists_ChangesTaskDetails()
        {
            // Arrange
            var repository = new InMemoryTaskRepository();
            var service = new TaskService(repository);

            var createdTask = service.Create(
                new Task_Management_Api.DTOs.CreateTaskRequest
                {
                    Title = "Learn C#",
                    Description = "Old description",
                    Assignee = "Mari",
                    DueDate = null
                });

            var updateRequest = new Task_Management_Api.DTOs.UpdateTaskRequest
            {
                Title = "Learn ASP.NET Core",
                Description = "New description",
                Assignee = "Alex",
                DueDate = null,
                Status = Task_Management_Api.Models.TaskStatus.IN_PROGRESS
            };

            // Act
            var result = service.Update(createdTask.Id, updateRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Learn ASP.NET Core", result.Title);
            Assert.Equal("New description", result.Description);
            Assert.Equal("Alex", result.Assignee);
            Assert.Equal(
                Task_Management_Api.Models.TaskStatus.IN_PROGRESS,
                result.Status);
        }


        [Fact]
        public void Update_WhenTaskDoesNotExist_ReturnsNull()
        {
            // Arrange
            var service = new TaskService(new InMemoryTaskRepository());

            var request = new Task_Management_Api.DTOs.UpdateTaskRequest
            {
                Title = "Updated task",
                Description = "Updated description",
                Assignee = "Alex",
                DueDate = null,
                Status = Task_Management_Api.Models.TaskStatus.TO_DO
            };

            // Act
            var result = service.Update(999, request);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void UpdateStatus_WhenTaskExists_ChangesStatus()
        {
            // Arrange
            var service = new TaskService(new InMemoryTaskRepository());

            var task = service.Create(
                new Task_Management_Api.DTOs.CreateTaskRequest
                {
                    Title = "Learn testing",
                    Assignee = "Alex"
                });

            var request = new Task_Management_Api.DTOs.UpdateTaskStatusRequest
            {
                Status = Task_Management_Api.Models.TaskStatus.IN_PROGRESS
            };

            // Act
            var result = service.UpdateStatus(task.Id, request);

            // Assert
            Assert.True(result);
            Assert.Equal(
                Task_Management_Api.Models.TaskStatus.IN_PROGRESS,
                service.GetById(task.Id)!.Status);
        }

        [Fact]
        public void UpdateStatus_WhenTaskDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var service = new TaskService(new InMemoryTaskRepository());

            var request = new Task_Management_Api.DTOs.UpdateTaskStatusRequest
            {
                Status = Task_Management_Api.Models.TaskStatus.DONE
            };

            // Act
            var result = service.UpdateStatus(999, request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Delete_WhenTaskExists_RemovesTask()
        {
            // Arrange
            var service = new TaskService(new InMemoryTaskRepository());

            var task = service.Create(
                new Task_Management_Api.DTOs.CreateTaskRequest
                {
                    Title = "Delete this task",
                    Assignee = "Alex"
                });

            // Act
            var result = service.Delete(task.Id);

            // Assert
            Assert.True(result);
            Assert.Null(service.GetById(task.Id));
        }

        [Fact]
        public void Delete_WhenTaskDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var service = new TaskService(new InMemoryTaskRepository());

            // Act
            var result = service.Delete(999);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Create_WhenAssigneeIsMissing_ThrowsArgumentException()
        {
            // Arrange
            var service = new TaskService(new InMemoryTaskRepository());

            var request = new Task_Management_Api.DTOs.CreateTaskRequest
            {
                Title = "Valid title",
                Assignee = " "
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => service.Create(request));
        }

        [Fact]
        public void Create_WhenDueDateIsInvalid_ThrowsArgumentException()
        {
            // Arrange
            var service = new TaskService(new InMemoryTaskRepository());

            var request = new Task_Management_Api.DTOs.CreateTaskRequest
            {
                Title = "Valid title",
                Assignee = "Alex",
                DueDate = DateTime.MinValue
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => service.Create(request));
        }

        [Fact]
        public void UpdateStatus_WhenStatusIsInvalid_ThrowsArgumentException()
        {
            // Arrange
            var service = new TaskService(new InMemoryTaskRepository());

            var task = service.Create(
                new Task_Management_Api.DTOs.CreateTaskRequest
                {
                    Title = "Valid title",
                    Assignee = "Alex"
                });

            var request = new Task_Management_Api.DTOs.UpdateTaskStatusRequest
            {
                Status = (Task_Management_Api.Models.TaskStatus)999
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => service.UpdateStatus(task.Id, request));
        }



    }
}
