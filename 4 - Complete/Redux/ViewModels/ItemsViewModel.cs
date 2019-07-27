﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Redux.Services;
using Redux.Models;
using System.Collections.Generic;
using Redux.Props;
using Redux.Store;
using System.Collections.Immutable;

namespace Redux.ViewModels
{
    public class ItemsViewModel  : BaseViewModel
    {
        private IDataStore<Item> _dataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        private readonly Store.Store _reduxStore;

        public ObservableCollection<ItemProps> Items { get; private set; } = new ObservableCollection<ItemProps>();
        public ObservableCollection<CategorySummaryProps> Summaries { get; private set; } = new ObservableCollection<CategorySummaryProps>();

        public Command LoadItemsCommand { get; }

        public ItemsViewModel()
        {
            _reduxStore = new Store.Store();
            _reduxStore.StateChanged += ReduxStoreOnStateChanged;
            
            LoadItemsCommand = new Command(async () => await LoadItems());
        }

        private void ReduxStoreOnStateChanged(State newState)
        {
            var props = new ItemsPropsMapper().MapState(newState, _reduxStore);

            if (Items.Count == 0)
            {
                Items = new ObservableCollection<ItemProps>(props.Items);
                OnPropertyChanged(nameof(Items));
            }

            Summaries = new ObservableCollection<CategorySummaryProps>(props.CategorySummaries);
            OnPropertyChanged(nameof(Summaries));

            Title = props.Title;
        }

        public string Title { get; set; }


        async Task LoadItems()
        {
            await _reduxStore.Dispatch(new LoadSaga(_dataStore));
        }
    }
}