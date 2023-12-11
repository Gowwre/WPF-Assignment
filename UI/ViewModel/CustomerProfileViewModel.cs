using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess.Services;
using System.Collections.ObjectModel;
using System.Windows;
using UI.Auth;

namespace UI.ViewModel {
    public partial class CustomerProfileViewModel : ObservableObject {
        private readonly ICustomerService _customerService;
        private readonly IRentingTransactionService _rentingTransactionService;

        [ObservableProperty] private Customer _customer;

        [ObservableProperty] private ObservableCollection<RentingTransaction> _customerRentingTransactions;

        public CustomerProfileViewModel(ICustomerService customerService,
            IRentingTransactionService rentingTransactionService) {
            _customerService = customerService;
            _rentingTransactionService = rentingTransactionService;
            _ = GetCustomerInfo();
            _ = GetCustomerRentingTransactions();
        }

        private async Task GetCustomerInfo() {
            AuthenticationResult? currentUser = Application.Current.Properties["CurrentUser"] as AuthenticationResult;
            if (currentUser == null) {
                MessageBox.Show("Please login first!");
                return;
            }

            Customer = await _customerService.GetCustomerInfo(currentUser.Email);
        }

        private async Task GetCustomerRentingTransactions() {
            if (Application.Current.Properties["CurrentUser"] is not AuthenticationResult currentUser) {
                MessageBox.Show("Please login first!");
                return;
            }

            List<RentingTransaction> result =
                await _rentingTransactionService.GetTransactionsByCustomerEmail(currentUser.Email);

            CustomerRentingTransactions = new ObservableCollection<RentingTransaction>();
            CustomerRentingTransactions.Clear();
            foreach (RentingTransaction item in result) {
                CustomerRentingTransactions.Add(item);
            }
        }
    }
}