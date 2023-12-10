using DataAccess.Entities;
using DataAccess.Services;
using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using UI.Auth;

namespace UI.ViewModel {
    public partial class CustomerProfileViewModel : ObservableObject {
        private readonly ICustomerService _customerService;
        private readonly IRentingTransactionService _rentingTransactionService;
        public CustomerProfileViewModel(ICustomerService customerService, IRentingTransactionService rentingTransactionService) {
            _customerService = customerService;
            _rentingTransactionService = rentingTransactionService; 
            _ =   GetCustomerInfo();
            _ = GetCustomerRentingTransactions();
        }

        [ObservableProperty]
        private Customer _customer;
        [ObservableProperty]
        private ObservableCollection<RentingTransaction> _customerRentingTransactions;
        
        private async Task GetCustomerInfo() {
            var currentUser = Application.Current.Properties["CurrentUser"] as AuthenticationResult;
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
            var result = await _rentingTransactionService.GetTransactionsByCustomerEmail(currentUser.Email);
           
            CustomerRentingTransactions = new ObservableCollection<RentingTransaction>();
            CustomerRentingTransactions.Clear();
            foreach (var item in result) {
                CustomerRentingTransactions.Add(item);
            }
        }
    }
}