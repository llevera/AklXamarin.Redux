using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using Redux.Models;
using Redux.Props;
using Redux.Services;

namespace Redux.Store
{
    public class Reducer : IReducer
    {
        private readonly IDataStore _dataStore;

        public Reducer(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public State Reduce(State state, IAction action)
        {
            switch (action)
            {
                case LoadAction _:
                {
                    return new State(accounts: _dataStore.GetMovies().ToImmutableArray());
                }

                case DepositAction depositAction:
                {
                    return AdjustBalance(accountName: depositAction.Title, change: 10);
                }
                case WithdrawAction withdrawAction:
                {
                    return AdjustBalance(accountName: withdrawAction.Title, change: -10);
                }

                default:
                {
                    throw new InvalidOperationException();
                }
            }

            State AdjustBalance(string accountName, int change)
            {
                var accounts = state.Accounts;

                var oldAccount = accounts.Single(x => x.Name == accountName);
                
                if (change > 0 ||
                    oldAccount.AccountType == AccountType.Credit ||
                    oldAccount.Balance + change >= 0)
                {
                    var newAccount = new Account(oldAccount.Name, oldAccount.Balance + change, oldAccount.AccountType);
                    return new State(state.Accounts.Replace(oldAccount, newAccount));
                }

                return state;
            }
        }
    }
}