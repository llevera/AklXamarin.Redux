using System;
using System.Collections.Generic;
using Redux.Models;

namespace Redux.Store
{
    public class State
    {
        public IList<Item> Items { get; }

        public State(IList<Item> items)
        {
            Items = items;
        }
    }
}