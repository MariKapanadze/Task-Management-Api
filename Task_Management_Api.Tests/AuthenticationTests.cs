
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Task_Management_Api.Data;
using Task_Management_Api.Models;
using Xunit;

namespace Task_Management_Api.Tests;

public class AuthenticationTests
{
    [Fact]
    public async Task GetTasks_WithoutAuthentication_ReturnsUnauthorized()
    {
        // Arrange
        using var factory = new CustomWebApplicationFactory();
        using var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/Tasks");

        // Assert
        Assert.Equal(
            HttpStatusCode.Unauthorized,
            response.StatusCode);
    }

    [Fact]
    public async Task GetTasks_WithValidUserCredentials_ReturnsOk()
    {
        // Arrange
        using var factory = new CustomWebApplicationFactory();

        using (var scope = factory.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider
                .GetRequiredService<TaskManagementDbContext>();

            await dbContext.Database.EnsureCreatedAsync();

            dbContext.Users.Add(new AppUser
            {
                Username = "testuser",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("TestPassword123!"),
                Role = "USER",
                Active = true,
                CreatedAt = DateTime.UtcNow
            });

            await dbContext.SaveChangesAsync();
        }

        using var client = factory.CreateClient();

        var credentials = Convert.ToBase64String(
            Encoding.UTF8.GetBytes("testuser:TestPassword123!"));

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", credentials);

        // Act
        var response = await client.GetAsync("/api/Tasks");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }


    [Fact]
    public async Task Register_WithValidDetails_ReturnsCreated()
    {
        // Arrange
        using var factory = new CustomWebApplicationFactory();
        using var client = factory.CreateClient();


        using (var scope = factory.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider
                .GetRequiredService<TaskManagementDbContext>();

            await dbContext.Database.EnsureCreatedAsync();
        }


        var request = new
        {
            Username = "newtestuser",
            Password = "TestPassword123!"
        };

        // Act
        var response = await client.PostAsJsonAsync(
            "/api/Auth/register",
            request);

        // Assert
        Assert.Equal(
            HttpStatusCode.Created,
            response.StatusCode);
    }


    [Fact]
    public async Task DeleteTask_AsRegularUser_ReturnsForbidden()
    {
        // Arrange
        using var factory = new CustomWebApplicationFactory();

        using (var scope = factory.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider
                .GetRequiredService<TaskManagementDbContext>();

            await dbContext.Database.EnsureCreatedAsync();

            dbContext.Users.Add(new AppUser
            {
                Username = "regularuser",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("TestPassword123!"),
                Role = "USER",
                Active = true,
                CreatedAt = DateTime.UtcNow
            });

            await dbContext.SaveChangesAsync();
        }

        using var client = factory.CreateClient();

        var credentials = Convert.ToBase64String(
            Encoding.UTF8.GetBytes("regularuser:TestPassword123!"));

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", credentials);

        // Act
        var response = await client.DeleteAsync("/api/Tasks/1");

        // Assert
        Assert.Equal(
            HttpStatusCode.Forbidden,
            response.StatusCode);
    }


    [Fact]
    public async Task DeleteTask_AsAdmin_ReturnsNoContent()
    {
        // Arrange
        using var factory = new CustomWebApplicationFactory();

        using (var scope = factory.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider
                .GetRequiredService<TaskManagementDbContext>();

            await dbContext.Database.EnsureCreatedAsync();

            dbContext.Users.Add(new AppUser
            {
                Username = "adminuser",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("TestPassword123!"),
                Role = "ADMIN",
                Active = true,
                CreatedAt = DateTime.UtcNow
            });

            dbContext.Tasks.Add(new Task_Management_Api.Models.TaskItem
            {
                Title = "Test task",
                Description = "Task created for an authorization test",
                Assignee = "adminuser",
                Status = Task_Management_Api.Models.TaskStatus.TO_DO,
                CreatedAt = DateTime.UtcNow
            });

            await dbContext.SaveChangesAsync();
        }

        using var client = factory.CreateClient();

        var credentials = Convert.ToBase64String(
            Encoding.UTF8.GetBytes("adminuser:TestPassword123!"));

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", credentials);

        // Act
        var response = await client.DeleteAsync("/api/Tasks/1");

        // Assert
        Assert.Equal(
            HttpStatusCode.NoContent,
            response.StatusCode);
    }


    [Fact]
    public async Task GetTasks_WithIncorrectPassword_ReturnsUnauthorized()
    {
        // Arrange
        using var factory = new CustomWebApplicationFactory();

        using (var scope = factory.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider
                .GetRequiredService<TaskManagementDbContext>();

            await dbContext.Database.EnsureCreatedAsync();

            dbContext.Users.Add(new AppUser
            {
                Username = "passwordtestuser",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("CorrectPassword123!"),
                Role = "USER",
                Active = true,
                CreatedAt = DateTime.UtcNow
            });

            await dbContext.SaveChangesAsync();
        }

        using var client = factory.CreateClient();

        // Deliberately use the wrong password.
        var credentials = Convert.ToBase64String(
            Encoding.UTF8.GetBytes("passwordtestuser:WrongPassword123!"));

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", credentials);

        // Act
        var response = await client.GetAsync("/api/Tasks");

        // Assert
        Assert.Equal(
            HttpStatusCode.Unauthorized,
            response.StatusCode);
    }


    [Fact]
    public async Task Register_WithExistingUsername_ReturnsBadRequest()
    {
        // Arrange
        using var factory = new CustomWebApplicationFactory();

        using (var scope = factory.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider
                .GetRequiredService<TaskManagementDbContext>();

            await dbContext.Database.EnsureCreatedAsync();

            dbContext.Users.Add(new AppUser
            {
                Username = "existinguser",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("ExistingPassword123!"),
                Role = "USER",
                Active = true,
                CreatedAt = DateTime.UtcNow
            });

            await dbContext.SaveChangesAsync();
        }

        using var client = factory.CreateClient();

        var request = new
        {
            Username = "existinguser",
            Password = "AnotherPassword123!"
        };

        // Act
        var response = await client.PostAsJsonAsync(
            "/api/Auth/register",
            request);

        // Assert
        Assert.Equal(
            HttpStatusCode.Conflict,
            response.StatusCode);
    }


}
