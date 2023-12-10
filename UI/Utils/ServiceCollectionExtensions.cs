using Backend.Repositories;
using Backend.Services;
using Microsoft.Extensions.DependencyInjection;
using UI.Auth;
using UI.View;
using UI.ViewModel;

namespace UI.Utils {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddWindowManager(this IServiceCollection serviceCollection) {
            serviceCollection.AddSingleton<IWindowManager, WindowManager>();
            return serviceCollection;
        } 
        
        public static IServiceCollection AddViewModels(this IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<LoginViewModel>();
            serviceCollection.AddTransient<AdminNavViewModel>();
            serviceCollection.AddTransient<CustomerNavViewModel>();
            serviceCollection.AddTransient<CarManagementViewModel>();
            serviceCollection.AddTransient<CustomerManagementViewModel>();
            serviceCollection.AddTransient<RentingTransactionManagementViewModel>();
            serviceCollection.AddTransient<CarFormViewModel>();
            serviceCollection.AddTransient<CustomerFormViewModel>();
            serviceCollection.AddTransient<CustomerProfileViewModel>();
            return serviceCollection;
        }
        
        public static IServiceCollection AddViews(this IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<LoginWindow>();
            serviceCollection.AddTransient<AdminWindow>();
            serviceCollection.AddTransient<CarManagementWindow>();
            serviceCollection.AddTransient<CustomerManagementWindow>();
            serviceCollection.AddTransient<RentingTransactionWindow>();
            serviceCollection.AddTransient<CarInformationFormWindow>();
            serviceCollection.AddTransient<CustomerFormWindow>();
            serviceCollection.AddTransient<CustomerWindow>();
            serviceCollection.AddTransient<CustomerProfileWindow>();
            return serviceCollection;
        }
        
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<ICustomerService, CustomerService>();
            serviceCollection.AddTransient<ICarInformationService, CarInformationService>();
            serviceCollection.AddTransient<ISupplierService, SupplierService>();
            serviceCollection.AddTransient<IManufacturerService, ManufacturerService>();
            serviceCollection.AddTransient<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddScoped<IRentingTransactionService, RentingTransactionService>();
            return serviceCollection;
        }
        
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddTransient<ICarInformationRepository, CarInformationRepository>();
            serviceCollection.AddTransient<ISupplierRepository, SupplierRepository>();
            serviceCollection.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            serviceCollection.AddScoped<IRentingTransactionRepository, RentingTransactionRepository>();
            return serviceCollection;
        }
    }
}