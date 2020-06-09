﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTrader.Domain.Exceptions
{
    public class InsufficientFundsException : Exception
    {

        public double AccountBalance { get; set; }
        public double RequiredBalance { get; set; }
        public InsufficientFundsException(double accountBalance, double requiredBalance)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

        public InsufficientFundsException(string message, double accountBalance, double requiredBalance) : base(message)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

        public InsufficientFundsException(string message, double accountBalance, double requiredBalance, Exception innerException) : base(message, innerException)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

    }
}
