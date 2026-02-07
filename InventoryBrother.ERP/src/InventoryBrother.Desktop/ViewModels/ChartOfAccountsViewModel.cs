using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBrother.Desktop.ViewModels;

public partial class ChartOfAccountsViewModel : ViewModelBase
{
    private readonly InventoryBrotherDbContext _dbContext;

    [ObservableProperty]
    private ObservableCollection<ChartOfAccount> _accounts = new();

    public ChartOfAccountsViewModel(InventoryBrotherDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadAccountsCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadAccounts()
    {
        var list = await _dbContext.ChartOfAccounts.OrderBy(c => c.AccountCode).ToListAsync();
        Accounts = new ObservableCollection<ChartOfAccount>(list);
    }
}
