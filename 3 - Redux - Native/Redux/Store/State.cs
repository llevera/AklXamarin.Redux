using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Redux.Models;

namespace Redux.Store
{
    public class State
    {
        public ImmutableArray<Account> Accounts { get; }

        public State(ImmutableArray<Account> accounts)
        {
            Accounts = accounts;
        }
    }
}