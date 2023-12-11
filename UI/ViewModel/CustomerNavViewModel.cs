using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Services;
using System.Windows;
using UI.Auth;

namespace UI.ViewModel {
    public partial class CustomerNavViewModel : ObservableObject {
        private readonly ICustomerService _customerService;
        private readonly IWindowManager _windowManager;

        public CustomerNavViewModel(IWindowManager windowManager, ICustomerService customerService) {
            _windowManager = windowManager;
            _customerService = customerService;
        }

        [RelayCommand]
        public void ShowProfile() {
            _windowManager.ShowCustomerProfileWindow();
        }

        [RelayCommand]
        public async Task ShowEditProfile() {
            AuthenticationResult? currentUser = Application.Current.Properties["CurrentUser"] as AuthenticationResult;

            if (currentUser == null) {
                MessageBox.Show("Please login first.");
                return;
            }

            Customer currentCustomer = await _customerService.GetCustomerInfo(currentUser.Email);

            _windowManager.ShowCustomerEditProfileWindow(currentCustomer);
        }
    }
}