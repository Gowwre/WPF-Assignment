using DataAccess.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using UI.Auth;

namespace UI.ViewModel;

public partial class CustomerNavViewModel : ObservableObject
{
    private readonly IWindowManager _windowManager;
    private readonly ICustomerService _customerService;

    public CustomerNavViewModel(IWindowManager windowManager, ICustomerService customerService) {
        this._windowManager = windowManager;
        this._customerService = customerService;
    }

    [RelayCommand]
    public void ShowProfile() => _windowManager.ShowCustomerProfileWindow();

    [RelayCommand]
    public async Task ShowEditProfile() {
        var currentUser = Application.Current.Properties["CurrentUser"] as AuthenticationResult;

        if (currentUser == null) {
            MessageBox.Show("Please login first.");
            return;
        }
        
        var currentCustomer = await _customerService.GetCustomerInfo(currentUser.Email);
        
        _windowManager.ShowCustomerEditProfileWindow(currentCustomer);
    }
}
