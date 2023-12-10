﻿using System.Windows;
using DataAccess.Repositories;
using DataAccess.Services;
using Microsoft.Extensions.DependencyInjection;
using UI.Utils;
using UI.View;
using UI.ViewModel;

namespace UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {
    private readonly IServiceProvider _serviceProvider;

    public App() {
        var serviceCollection = new ServiceCollection();
        this.ConfigureServices(serviceCollection);
        this._serviceProvider = serviceCollection.BuildServiceProvider();
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
        var loginViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();
        var loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();

        loginWindow.DataContext = loginViewModel;
        loginWindow.Show();
    }
}