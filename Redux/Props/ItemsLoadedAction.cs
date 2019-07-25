using System.Collections.Immutable;
using Redux.Models;
using Redux.Store;

namespace Redux.Props
{
    public class ItemsLoadedAction : IAction
    {
        private readonly ImmutableArray<Item> _items;

        public ItemsLoadedAction(ImmutableArray<Item> items)
        {
            _items = items;
        }

        public State Reduce(State state)
        {
            return new State(_items);
        }
    }
}