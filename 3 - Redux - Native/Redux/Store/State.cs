using System.Collections.Immutable;
using Redux.Models;

namespace Redux.Store
{
    public class State
    {
        public State(ImmutableArray<Account> accounts)
        {
            Accounts = accounts;
        }

        public ImmutableArray<Account> Accounts { get; }
    }
}