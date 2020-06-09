using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IDataService<Account> _accountDataService;

        public AuthenticationService(IDataService<Account> accountDataService)
        {
            this._accountDataService = accountDataService;
        }

        public async Task<Account> Login(string username, string password)
        {
            return new Account();
        }

        public async Task<bool> Register(string email, string username, string password, string confirmPassword)
        {
            bool success = false;
            if (password == confirmPassword)
            {
                IPasswordHasher hasher = new PasswordHasher();
                string HashedPassword = hasher.HashPassword(password);

                User user = new User()
                {
                    Email = email,
                    Username = username,
                    PasswordHash = HashedPassword
                };

                Account account = new Account()
                {
                    AccountHolder = user
                };

                await _accountDataService.Create(account);
            }

            return success;
        }
    }
}
