using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using UI.Auth;

namespace UI.ViewModel {
    public partial class LoginViewModel : ObservableObject {
        private readonly IAuthenticationService _authenticationService;
        private readonly IWindowManager _windowManager;

        [ObservableProperty] private string _email = string.Empty;

        [ObservableProperty] private string _errorMessage = string.Empty;

        [ObservableProperty] private string _password = string.Empty;

        public LoginViewModel(IAuthenticationService authenticationService, IWindowManager windowManager) {
            _authenticationService = authenticationService;
            _windowManager = windowManager;
        }

        [RelayCommand]
        public async Task Login() {
            AuthenticationResult result = await _authenticationService.Login(Email, Password);

            if (result.IsAuthenticated) {
                if (result.Role == UserRole.Admin) {
                    _windowManager.ShowAdminWindow();
                } else {
                    Application.Current.Properties["CurrentUser"] = result;
                    _windowManager.ShowCustomerWindow();
                }

                _windowManager.CloseLoginWindow();
            } else {
                ErrorMessage = "Login Failed";
            }
        }

        [RelayCommand]
        public void Register() {
            _windowManager.ShowCustomerFormWindow();
        }
    }
}