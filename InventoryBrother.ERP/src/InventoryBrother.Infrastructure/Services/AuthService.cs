using System.Security.Cryptography;
using System.Text;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
    public int? CurrentStoreId { get; private set; }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var user = await _dbContext.AspnetUsers
            .Include(u => u.AspnetMembership)
            .FirstOrDefaultAsync(u => u.LoweredUserName == username.ToLower());

        if (user == null || user.AspnetMembership == null)
            return false;

        // Verify password (simplified for now, supporting hashed password format 1)
        if (VerifyPassword(password, user.AspnetMembership.Password, user.AspnetMembership.PasswordSalt, user.AspnetMembership.PasswordFormat))
        {
            CurrentUserName = user.UserName;
            CurrentUserId = user.UserId.ToString();
            CurrentStoreId = user.StoreId;
            return true;
        }

        return false;
    }

    public Task LogoutAsync()
    {
        CurrentUserName = null;
        CurrentUserId = null;
        CurrentStoreId = null;
        return Task.CompletedTask;
    }

    public bool IsLoggedIn() => !string.IsNullOrEmpty(CurrentUserName);

    private bool VerifyPassword(string inputPassword, string storedPassword, string salt, int format)
    {
        // Format 1 = Hashed (SHA1 by default in old ASP.NET Membership)
        if (format == 0) // Clear
            return inputPassword == storedPassword;
            
        // Simplified hashing check for the walkthrough. In production, use the exact algorithm.
        // Legacy SHA1 hashing logic:
        var combined = salt + inputPassword;
        using var sha1 = SHA1.Create();
        var hashedBytes = sha1.ComputeHash(Encoding.Unicode.GetBytes(combined));
        var hashedString = Convert.ToBase64String(hashedBytes);
        
        return hashedString == storedPassword;
    }
}
