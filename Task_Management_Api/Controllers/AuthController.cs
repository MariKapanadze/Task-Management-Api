using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Management_Api.Data;
using Task_Management_Api.DTOs;
using Task_Management_Api.Models;
using Task_Management_Api.Services;

namespace Task_Management_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TaskManagementDbContext _dbContext;
    private readonly PasswordService _passwordService;

    public AuthController(
        TaskManagementDbContext dbContext,
        PasswordService passwordService)
    {
        _dbContext = dbContext;
        _passwordService = passwordService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var username = request.Username.Trim();

        var usernameExists = await _dbContext.Users
            .AnyAsync(u => u.Username == username);

        if (usernameExists)
        {
            return Conflict(new
            {
                message = "That username is already taken."
            });
        }

        var user = new AppUser
        {
            Username = username,
            PasswordHash = _passwordService.HashPassword(request.Password),
            Role = "USER",
            Active = true,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return Created("/api/auth/register", new
        {
            user.Id,
            user.Username,
            user.Role,
            user.Active,
            user.CreatedAt
        });
    }
}
