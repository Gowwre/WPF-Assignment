
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using UI.Auth;

namespace UI.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string _email = string.Empty;
    [ObservableProperty]
    private string _password = string.Empty;
    [ObservableProperty]
    private string _errorMessage = string.Empty;
    private readonly IAuthenticationService _authenticationService;
    private readonly IWindowManager _windowManager;

    public LoginViewModel(IAuthenticationService authenticationService, IWindowManager windowManager)
    {
        this._authenticationService = authenticationService;
        this._windowManager = windowManager;
    }

    [RelayCommand]
    public async Task Login()
    {
        var result = await this._authenticationService.Login(this.Email, this.Password);

        if (result.IsAuthenticated)
        {
            if (result.Role == UserRole.Admin)
            {
                this._windowManager.ShowAdminWindow();
            }
            else
            {
                Application.Current.Properties["CurrentUser"] = result;
                this._windowManager.ShowCustomerWindow();
            }
            this._windowManager.CloseLoginWindow();
        }
        else
        {
            this.ErrorMessage = "Login Failed";
        }

    }

    [RelayCommand]
    public void Register() {
        this._windowManager.ShowCustomerFormWindow();
    }


}
