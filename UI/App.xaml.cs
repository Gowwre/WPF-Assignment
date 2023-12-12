using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using UI.Utils;
using UI.View;
using UI.ViewModel;

namespace UI {
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private readonly IServiceProvider _serviceProvider;

        public App() {
            ServiceCollection serviceCollection = new();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection serviceCollection) {
            serviceCollection
                .AddRepositories()
                .AddServices()
                .AddViews()
                .AddViewModels()
                .AddWindowManager();
        }

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            LoginViewModel loginViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();
            LoginWindow loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();

            loginWindow.DataContext = loginViewModel;
            loginWindow.Show();
        }
    }
}