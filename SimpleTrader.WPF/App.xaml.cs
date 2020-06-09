using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Models;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleTrader.EntityFramework.Models;
using SimpleTrader.EntityFramework.Services;
using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services.TransactionServices;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Factories;
using SimpleTrader.Domain.Services.AuthenticationServices;

namespace SimpleTrader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            IServiceProvider serviceProvider = CreateServiceProvider();

            Window Window = serviceProvider.GetRequiredService<MainWindow>();
            Window.Show();

            base.OnStartup(e);

        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IStockPriceService, StockPriceService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<SimpleTraderDbContextFactory>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IRootSimpleTraderViewModelFactory, RootSimpleTraderViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
            services.AddSingleton<ISimpleTraderViewModelFactory<MajorIndexListingViewModel>, MajorIndexListingViewModelFactory>();

            services.AddScoped<BuyViewModel>();
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
