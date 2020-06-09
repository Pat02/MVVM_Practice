using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTrader.Domain.Exceptions
{
    public class InValidSymbolException : Exception
    {

        public string Symbol { get; set; }
        public InValidSymbolException(string symbol)
        {
            Symbol = symbol;
        }

        public InValidSymbolException(string symbol, string message) : base(message)
        {
            Symbol = symbol;
        }

        public InValidSymbolException(string symbol, string message, Exception innerException) : base(message, innerException)
        {
            Symbol = symbol;
        }
    }
}
