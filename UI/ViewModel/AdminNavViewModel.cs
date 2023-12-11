using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModel {
    public partial class AdminNavViewModel : ObservableObject {
        private readonly IWindowManager _windowManager;

        public AdminNavViewModel(IWindowManager windowManager) {
            _windowManager = windowManager;
        }

        [RelayCommand]
        public void OpenCarManagementWindow() {
            _windowManager.ShowCarManagementWindow();
        }

        [RelayCommand]
        public void OpenCustomerManagementWindow() {
            _windowManager.ShowCustomerManagementWindow();
        }

        [RelayCommand]
        public void OpenRentingTransactionWindow() {
            _windowManager.ShowRentingTransactionWindow();
        }
    }
}