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
        private IDataStore<Item> _dataStore => new MockDataStore();

        public ObservableCollection<ItemViewModel> Items { get; } = new ObservableCollection<ItemViewModel>();

        public ObservableCollection<CategorySummaryViewModel> Summaries { get; } =
            new ObservableCollection<CategorySummaryViewModel>();

        public Command LoadItemsCommand { get; private set; }
        public IList<Item> _items;

        public ItemsViewModel()
        {
            LoadItemsCommand = new Command(async () => await LoadItems());
        }

        public void UpdateSummaries()
        {
            var summaryViewModels = _items
                .GroupBy(x => x.Category)
                .Select(x => new CategorySummaryViewModel(x.Key.ToString(), x.Sum(y => y.Quantity)));

            foreach (var summary in summaryViewModels)
            {
                var existingSummary = Summaries.FirstOrDefault(x => x.CategoryLabel == summary.CategoryLabel);

                if (existingSummary == null)
                    Summaries.Add(summary);
                else
                    existingSummary.CategoryQuantity = summary.CategoryQuantity;
            }
        }

        private async Task LoadItems()
        {
            _items = (await _dataStore.GetItemsAsync()).ToList();

            var itemViewModels = _items.Select(x => new ItemViewModel(x, this));

            foreach (var item in itemViewModels) Items.Add(item);

            UpdateSummaries();
        }
    }
}