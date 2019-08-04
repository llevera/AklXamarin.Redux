using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Redux.Models;
using Redux.Services;
using Redux.Store;

namespace Redux.Props
{
    public class LoadAction : IAction
    {
        private readonly IDataStore _dataStore;

        public LoadAction(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public State Reduce(State state)
        {
            return new State(_dataStore.GetMovies().ToImmutableArray());
        }

    }
}