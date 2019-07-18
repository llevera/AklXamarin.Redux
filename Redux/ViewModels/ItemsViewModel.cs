using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Redux.Services;
using Redux.Models;
using System.Collections.Generic;

namespace Redux.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        public ObservableCollection<ItemViewModel> Items { get; } = new ObservableCollection<ItemViewModel>();
        public ObservableCollection<CategorySummary> Summaries { get; } = new ObservableCollection<CategorySummary>();
        public Command LoadItemsCommand { get; private set; }
        public IList<Item> _items;

        public ItemsViewModel()
        {
            Title = "Shopping";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public string Title { get; set; }

        public void UpdateSummaries()
        {
            var summaryViewModels = _items
                .GroupBy(x => x.Category)
                .Select(x => new CategorySummary(x.Key.ToString(), x.Sum(y => y.Quantity)));

            foreach (var summary in summaryViewModels)
            {
                var existingSummary = Summaries.FirstOrDefault(x => x.CategoryLabel == summary.CategoryLabel);

                if (existingSummary == null)
                {
                    Summaries.Add(summary);
                }
                else
                {
                    existingSummary.CategoryQuantity = summary.CategoryQuantity;
                }
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            _items = (await DataStore.GetItemsAsync(true)).ToList();

            var itemViewModels = _items.Select(x => new ItemViewModel(x, this));

            foreach(var item in itemViewModels)
            {
                Items.Add(item);
            }

            UpdateSummaries();
        }
    }
}