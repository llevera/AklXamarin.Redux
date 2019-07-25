using System.Collections.Immutable;
using System.Threading.Tasks;
using Redux.Models;
using Redux.Services;
using Redux.Store;

namespace Redux.Props
{
    public class LoadSaga : ISaga
    {
        private readonly IDataStore<Item> _dataStore;

        public LoadSaga(IDataStore<Item> dataStore)
        {
            _dataStore = dataStore;
        }
        
        public async Task Handle(Store.Store store)
        {
            var items = await _dataStore.GetItemsAsync();
            store.Dispatch(new ItemsLoadedAction(items.ToImmutableArray()));
        }
    }
}