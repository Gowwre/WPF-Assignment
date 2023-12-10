using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModel;

public partial class AdminNavViewModel : ObservableObject
{
    private readonly IWindowManager _windowManager;
    public AdminNavViewModel(IWindowManager windowManager) => this._windowManager = windowManager;

    [RelayCommand]
    public void OpenCarManagementWindow() => this._windowManager.ShowCarManagementWindow();

    [RelayCommand]
    public void OpenCustomerManagementWindow() => this._windowManager.ShowCustomerManagementWindow();

    [RelayCommand]
    public void OpenRentingTransactionWindow() => this._windowManager.ShowRentingTransactionWindow();
}
