
using Backend.Services;
using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace UI.ViewModel;

public partial class RentingTransactionManagementViewModel: ObservableObject
{
    private readonly IRentingTransactionService _rentingTransactionService;
    private readonly IWindowManager _windowManager;
    
    public RentingTransactionManagementViewModel(IRentingTransactionService rentingTransactionService, IWindowManager windowManager)
    {
        _rentingTransactionService = rentingTransactionService;
        _windowManager = windowManager;
        
        RentingTransactions = new ObservableCollection<RentingTransaction>();
        
        _ = GetRentingTransactions();
    }

    [ObservableProperty] private ObservableCollection<RentingTransaction> _rentingTransactions;

    private async Task GetRentingTransactions() {
        var result = await _rentingTransactionService.GetRentingTransactions();
        
       RentingTransactions.Clear(); 
       
        foreach (var item in result) {
            RentingTransactions.Add(item);
        }
    }
}
