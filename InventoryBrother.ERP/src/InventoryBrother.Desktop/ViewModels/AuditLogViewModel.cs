using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryBrother.Desktop.ViewModels;

public partial class AuditLogViewModel : ViewModelBase
{
    private readonly InventoryBrotherDbContext _dbContext;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _searchKey = string.Empty;

    public ObservableCollection<AuditLog> AuditLogs { get; } = new();

    public AuditLogViewModel(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadLogsCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadLogsAsync()
    {
        IsBusy = true;
        try
        {
            var logs = await _dbContext.AuditLogs
                .OrderByDescending(l => l.Timestamp)
                .Take(200)
                .ToListAsync();

            AuditLogs.Clear();
            foreach (var log in logs)
            {
                AuditLogs.Add(log);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchKey))
        {
            await LoadLogsAsync();
            return;
        }

        IsBusy = true;
        try
        {
            var logs = await _dbContext.AuditLogs
                .Where(l => l.TableName.Contains(SearchKey) || l.Action.Contains(SearchKey))
                .OrderByDescending(l => l.Timestamp)
                .Take(200)
                .ToListAsync();

            AuditLogs.Clear();
            foreach (var log in logs)
            {
                AuditLogs.Add(log);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
