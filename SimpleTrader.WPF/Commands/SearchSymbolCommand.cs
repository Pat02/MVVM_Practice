using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    class SearchSymbolCommand : ICommand
    {
        private BuyViewModel _buyViewModel;
        private IStockPriceService _stockPriceService;
        public SearchSymbolCommand(BuyViewModel viewModel, IStockPriceService stockPriceService)
        {
            _buyViewModel = viewModel;
            _stockPriceService = stockPriceService;
        }

        public event EventHandler CanExecuteChanged;



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                double stockPrice = await _stockPriceService.GetPrice(_buyViewModel.Symbol);
                _buyViewModel.SearchResultSymbol = _buyViewModel.Symbol.ToUpper();
                _buyViewModel.StockPrice = stockPrice;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
