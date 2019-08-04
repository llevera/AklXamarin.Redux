using System.Collections.Immutable;
using Redux.Models;
using Redux.Store;

namespace Redux.Props
{
    public class MoviesLoadedAction : IAction
    {
        private readonly ImmutableArray<Movie> _items;

        public MoviesLoadedAction(ImmutableArray<Movie> items)
        {
            _items = items;
        }

        public State Reduce(State state)
        {
            return new State(_items);
        }
    }
}