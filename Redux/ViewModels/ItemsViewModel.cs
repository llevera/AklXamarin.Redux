using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Redux.Services;
using Redux.Models;
using System.Collections.Generic;
using Redux.Props;
using Redux.Store;

namespace Redux.ViewModels
{
    public class ItemsViewModel 
    {
        private IDataStore<Item> _dataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        private readonly Store.Store _reduxStore;
        
        public ObservableCollection<ItemProps> Items { get; } = new ObservableCollection<ItemProps>();
        public ObservableCollection<CategorySummaryProps> Summaries { get; } = new ObservableCollection<CategorySummaryProps>();

        public Command LoadItemsCommand { get; }

        public ItemsViewModel()
        {
            _reduxStore = new Store.Store();
            _reduxStore.StateChanged += ReduxStoreOnStateChanged;
            
            LoadItemsCommand = new Command(async () => await LoadItems());
        }

        private void ReduxStoreOnStateChanged(State newState)
        {
            var props = new ItemsPropsMapper().MapState(newState);
            
            Items.Clear();

            foreach (var item in props.Items)
            {
                Items.Add(item);
            }
 
            Summaries.Clear();
            
            foreach (var summary in props.CategorySummaries)
            {
                Summaries.Add(summary);
            }

            Title = props.Title;
        }

        public string Title { get; set; }


        async Task LoadItems()
        {
            await _reduxStore.Dispatch(new LoadSaga(_dataStore));
        }
    }
}