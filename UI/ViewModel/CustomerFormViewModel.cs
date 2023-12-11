using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Services;

namespace UI.ViewModel {
    public partial class CustomerFormViewModel : ObservableObject {
        private readonly ICustomerService _customerService;
        private readonly IWindowManager _windowManager;

        [ObservableProperty] private Customer _customer = new();

        public CustomerFormViewModel(ICustomerService customerService, IWindowManager windowManager) {
            _customerService = customerService;
            _windowManager = windowManager;
        }

        public bool IsEdit { get; set; } = false;

        [RelayCommand]
        public async Task SaveCustomer() {
            Customer input = Customer;

            if (IsEdit) {
                await _customerService.EditCustomer(input);
            } else {
                await _customerService.RegisterCustomer(input);
            }

            _windowManager.CloseCustomerFormWindow();
        }
    }
}