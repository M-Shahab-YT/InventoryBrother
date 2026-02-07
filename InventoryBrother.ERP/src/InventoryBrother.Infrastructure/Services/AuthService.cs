using System.Security.Cryptography;
using System.Text;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities; // For User entity
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace InventoryBrother.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly InventoryBrotherDbContext _dbContext;
    
    public AuthService(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string? CurrentUserName { get; private set; }
    public string? CurrentUserId { get; private set; }
    public string? CurrentUserRole { get; private set; }
    public int? CurrentStoreId { get; private set; }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower() && u.IsActive);

        if (user == null)
        {
            // Seed Admin user if no users exist (for first run dev convenience)
            if (!await _dbContext.Users.AnyAsync())
            {
                user = await SeedAdminUserAsync();
                if (user.Username.ToLower() != username.ToLower()) return false;
            }
            else
            {
                return false;
            }
        }

        if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            CurrentUserName = user.Username;
            CurrentUserId = user.Id.ToString();
            CurrentUserRole = user.Role;
            CurrentStoreId = user.StoreId;
            return true;
        }

        return false;
    }

    private async Task<User> SeedAdminUserAsync()
    {
        var admin = new User
        {
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
            FirstName = "System",
            LastName = "Admin",
            Role = "Admin",
            Email = "admin@inventorybrother.com",
            StoreId = 1,
            CreatedBy = "System",
            CreatedAt = DateTime.Now
        };

        _dbContext.Users.Add(admin);
        await _dbContext.SaveChangesAsync();
        return admin;
    }

    public Task LogoutAsync()
    {
        CurrentUserName = null;
        CurrentUserId = null;
        CurrentUserRole = null;
        CurrentStoreId = null;
        return Task.CompletedTask;
    }

    public bool IsLoggedIn() => !string.IsNullOrEmpty(CurrentUserName);
}
