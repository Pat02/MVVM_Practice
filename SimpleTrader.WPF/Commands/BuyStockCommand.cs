﻿using SimpleTrader.Domain.Models;
using SimpleTrader.EntityFramework.Services.TransactionServices;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {

        private BuyViewModel _buyViewModel;
        private IBuyStockService _buyStockService;

        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService)
        {
            _buyViewModel = buyViewModel;
            _buyStockService = buyStockService;
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
                Account account = await _buyStockService.BuyStock(new Account()
                {
                    Id = 4,
                    Balance = 5000,
                    AssetTransactions = new List<AssetTransaction>()
                },
                     _buyViewModel.Symbol,
                     _buyViewModel.SharesToBuy
                     );
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
