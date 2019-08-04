using System.Collections.Generic;
using Redux.Models;

namespace Redux.Services
{
    public class MockDataStore : IDataStore
    {
        private readonly List<Account> _accounts;

        public MockDataStore()
        {
            _accounts = new List<Account>(new[]
            {
                new Account("Alfred Expenses", 100, AccountType.Cheque),
                new Account("Holiday to Jamaica", 200, AccountType.Savings),
                new Account("Wayne Manor", -1000, AccountType.Mortgage),
                new Account("iTunes (Fortnite)", 0, AccountType.Credit),
                new Account("New Batmobile", 100, AccountType.Savings),
            });
        }

        public IEnumerable<Account> GetMovies()
        {
            return _accounts;
        }
    }
}