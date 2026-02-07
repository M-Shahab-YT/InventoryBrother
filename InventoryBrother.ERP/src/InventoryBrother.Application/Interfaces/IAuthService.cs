namespace InventoryBrother.Application.Interfaces;

public interface IAuthService
{
    Task<bool> LoginAsync(string username, string password);
    Task LogoutAsync();
    bool IsLoggedIn();
    string? CurrentUserName { get; }
    string? CurrentUserId { get; }
    string? CurrentUserRole { get; }
    int? CurrentStoreId { get; }
}
