using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace UI.ViewModel {
    public partial class CustomerManagementViewModel : ObservableObject {
        private readonly ICustomerService _customerService;
        private readonly IWindowManager _windowManager;

        [ObservableProperty] private ObservableCollection<Customer> _customers;

        [ObservableProperty] private Customer _selectedCustomer;

        public CustomerManagementViewModel(ICustomerService customerService, IWindowManager windowManager) {
            _customerService = customerService;
            _windowManager = windowManager;

            Customers = new ObservableCollection<Customer>();
            _ = GetCustomerList();
        }

        [RelayCommand]
        public async Task GetCustomerList() {
            List<Customer> customers = await _customerService.GetCustomers();
            Customers.Clear();
            foreach (Customer customer in customers) {
                Customers.Add(customer);
            }
        }

        [RelayCommand]
        public async Task DeleteCustomer() {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No) {
                return;
            }

            Customer input = SelectedCustomer;
            try {
                await _customerService.DeleteCustomer(input);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }

            await GetCustomerList();
        }
    }
}