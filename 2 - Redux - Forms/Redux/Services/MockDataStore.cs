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
                new Account("Ice Javelins (etc)", 100, AccountType.Cheque),
                new Account("Swimming Lessons", 200, AccountType.Cheque),
                new Account("Wall Damage Repayments", -1000, AccountType.Loan),
                new Account("Season 8 Remake", 0, AccountType.Savings),
                new Account("Payroll", 800, AccountType.Cheque),
                new Account("Snowmobile", 100, AccountType.Savings),
                new Account("Dragon Food", 20, AccountType.Credit)
            });
        }

        public IEnumerable<Account> GetMovies()
        {
            return _accounts;
        }
    }
}