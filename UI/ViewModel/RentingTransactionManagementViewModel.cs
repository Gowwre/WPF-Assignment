using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess.Services;
using System.Collections.ObjectModel;

namespace UI.ViewModel {
    public partial class RentingTransactionManagementViewModel : ObservableObject {
        private readonly IRentingTransactionService _rentingTransactionService;
        private readonly IWindowManager _windowManager;

        [ObservableProperty] private ObservableCollection<RentingTransaction> _rentingTransactions;
        [ObservableProperty] private RentingTransaction _selectedRentingTransaction;

        public RentingTransactionManagementViewModel(IRentingTransactionService rentingTransactionService,
            IWindowManager windowManager) {
            _rentingTransactionService = rentingTransactionService;
            _windowManager = windowManager;

            RentingTransactions = new ObservableCollection<RentingTransaction>();

            _ = GetRentingTransactions();
        }

        private async Task GetRentingTransactions() {
            List<RentingTransaction> result = await _rentingTransactionService.GetRentingTransactions();

            RentingTransactions.Clear();

            foreach (RentingTransaction item in result) {
                RentingTransactions.Add(item);
            }
        }
    }
}