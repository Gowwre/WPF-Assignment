
using System.Windows;
using DataAccess.Entities;
using BusinessObjects.Entities;
using Microsoft.Extensions.DependencyInjection;
using UI.View;
using UI.ViewModel;

namespace UI;

public class WindowManager : IWindowManager
{

    private readonly IServiceProvider _serviceProvider;


    public WindowManager(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public void CloseLoginWindow() => Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault()?.Close();

    private void ShowWindow<TWindow, TViewModel>() where TWindow : Window where TViewModel : class
    {
        var window = _serviceProvider.GetRequiredService<TWindow>();
        var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
        window.DataContext = viewModel;
        window.Show();
    }

    public void ShowCarManagementWindow() => ShowWindow<CarManagementWindow, CarManagementViewModel>();

    public void ShowCustomerManagementWindow()
    {
        var customerManagementWindow = _serviceProvider.GetRequiredService<CustomerManagementWindow>();
        var viewModel = _serviceProvider.GetRequiredService<CustomerManagementViewModel>();
        customerManagementWindow.DataContext = viewModel;
        customerManagementWindow.Show();
    }

    public void ShowRentingTransactionWindow()
    {
        ShowWindow<RentingTransactionWindow,RentingTransactionManagementViewModel>();
    }

    public void ShowAdminWindow() => ShowWindow<AdminWindow, AdminNavViewModel>();

    public void ShowCustomerWindow()
    {
       ShowWindow<CustomerWindow,CustomerNavViewModel>(); 
    }

    public void ShowCarInformationForm() => ShowWindow<CarInformationFormWindow, CarFormViewModel>();

    public void ShowCarInformationEditForm(CarInformation selectedCarInformation)
    {
        var window = _serviceProvider.GetRequiredService<CarInformationFormWindow>();
        window.Title = "Edit Car Information";
        var viewModel = _serviceProvider.GetRequiredService<CarFormViewModel>();
        viewModel.IsEdit = true;
        viewModel.CarInformation = selectedCarInformation;
        viewModel.SelectedManufacturer = selectedCarInformation.Manufacturer;
        viewModel.SelectedSupplier = selectedCarInformation.Supplier;
        window.DataContext = viewModel;
        window.Show();
    }

    public void CloseCarInformationForm() => Application.Current.Windows.OfType<CarInformationFormWindow>().FirstOrDefault()?.Close();

    public void RefreshCarManagementWindow()
    {
        Application.Current.Windows.OfType<CarManagementWindow>().FirstOrDefault()?.Close();
        ShowCarManagementWindow();
    }

    public void ShowCustomerFormWindow() {
        ShowWindow<CustomerFormWindow, CustomerFormViewModel>();
    }
    
    public void CloseCustomerFormWindow() => Application.Current.Windows.OfType<CustomerFormWindow>().FirstOrDefault()?.Close();
    public void ShowCustomerProfileWindow() {
        ShowWindow<CustomerProfileWindow, CustomerProfileViewModel>();
    }

    public void ShowCustomerEditProfileWindow(Customer currentCustomer) {
        var window = _serviceProvider.GetRequiredService<CustomerFormWindow>();
        var viewModel = _serviceProvider.GetRequiredService<CustomerFormViewModel>();
        viewModel.Customer = currentCustomer;
        window.Title = "Edit Information";
        viewModel.IsEdit = true;
        window.DataContext = viewModel;
        window.Show();
    }
}

