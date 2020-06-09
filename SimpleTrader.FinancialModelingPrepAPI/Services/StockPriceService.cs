using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Models;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using System.Text.Json;
using SimpleTrader.Domain.Exceptions;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string uri = "stock/real-time-price/" + symbol + @"?apikey=b346753a14deb665d5489815d0a56b42";

                StockPriceResult stockPriceResult = await client.GetAsync<StockPriceResult>(uri);
                if (stockPriceResult.price == 0)
                {
                    throw new InValidSymbolException(symbol);
                }

                return stockPriceResult.price;
            }
        }
    }
}
