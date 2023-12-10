using DataAccess.Entities;
using DataAccess.Services;
using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace UI.ViewModel;

public partial class CustomerManagementViewModel : ObservableObject
{
    private readonly IWindowManager _windowManager;
    private readonly ICustomerService _customerService;

    public CustomerManagementViewModel(ICustomerService customerService, IWindowManager windowManager) {
        _customerService = customerService;
        _windowManager = windowManager;

        Customers = new ObservableCollection<Customer>();
        _ = GetCustomerList();
    }

    [ObservableProperty]
    private ObservableCollection<Customer> _customers;
    [ObservableProperty]
    private Customer _selectedCustomer;

    [RelayCommand]
    public async Task GetCustomerList() {
        var customers = await _customerService.GetCustomers();
        Customers.Clear();
        foreach (var customer in customers) {
            Customers.Add(customer);
        }
    }

    [RelayCommand]
    public async Task DeleteCustomer() {
        var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation", MessageBoxButton.YesNo);

        if (result == MessageBoxResult.No) {
            return;
        }

        var input = SelectedCustomer;
        try {
            await _customerService.DeleteCustomer(input);
        } catch (Exception ex) {
            MessageBox.Show(ex.Message);
            return;
        }
        await GetCustomerList();
    }
}
