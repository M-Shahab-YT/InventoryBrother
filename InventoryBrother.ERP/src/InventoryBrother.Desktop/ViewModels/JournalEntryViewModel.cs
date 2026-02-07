using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryBrother.Application.DTOs.Accounting;
using InventoryBrother.Application.Interfaces;
using InventoryBrother.Infrastructure.Data;
using InventoryBrother.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryBrother.Desktop.ViewModels;

public partial class JournalEntryViewModel : ViewModelBase
{
    private readonly IAccountingService _accountingService;
    private readonly InventoryBrotherDbContext _dbContext;

    [ObservableProperty]
    private DateTime _entryDate = DateTime.Now;

    [ObservableProperty]
    private string _referenceNumber = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private ObservableCollection<ChartOfAccount> _accountList = new();

    [ObservableProperty]
    private ObservableCollection<JournalEntryLineViewModel> _lines = new();

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    public JournalEntryViewModel(IAccountingService accountingService, InventoryBrotherDbContext dbContext)
    {
        _accountingService = accountingService;
        _dbContext = dbContext;
        LoadAccounts();
        
        // Add default lines
        Lines.Add(new JournalEntryLineViewModel());
        Lines.Add(new JournalEntryLineViewModel());
    }

    private async void LoadAccounts()
    {
        var list = await _dbContext.ChartOfAccounts.OrderBy(c => c.AccountCode).ToListAsync();
        AccountList = new ObservableCollection<ChartOfAccount>(list);
    }

    [RelayCommand]
    private void AddLine()
    {
        Lines.Add(new JournalEntryLineViewModel());
    }

    [RelayCommand]
    private async Task SaveEntry()
    {
        try
        {
            var dto = new JournalEntryDto
            {
                Date = EntryDate,
                ReferenceNumber = ReferenceNumber,
                Description = Description,
                IsAutoPosted = false,
                Lines = Lines.Where(l => l.SelectedAccount != null && (l.Debit > 0 || l.Credit > 0))
                             .Select(l => new JournalEntryLineDto
                             {
                                 AccountId = l.SelectedAccount!.AccountId,
                                 Description = l.Memo ?? Description,
                                 Debit = l.Debit,
                                 Credit = l.Credit
                             }).ToList()
            };

            await _accountingService.CreateJournalEntryAsync(dto);
            StatusMessage = "Journal Entry Saved Successfully!";
            
            // Reset
            ReferenceNumber = "";
            Description = "";
            Lines.Clear();
            AddLine();
            AddLine();
        }
        catch (Exception)
        {
            // Handle error (maybe add ErrorMessage to ViewModelBase)
        }
    }
}

public partial class JournalEntryLineViewModel : ObservableObject
{
    [ObservableProperty]
    private ChartOfAccount? _selectedAccount;

    [ObservableProperty]
    private string? _memo;

    [ObservableProperty]
    private decimal _debit;

    [ObservableProperty]
    private decimal _credit;
}
