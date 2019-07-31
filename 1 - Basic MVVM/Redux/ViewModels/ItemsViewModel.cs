using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Redux.Services;
using Redux.Models;

namespace Redux.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly IDataStore<Item> _dataStore = new MockDataStore();

        public ObservableCollection<ItemViewModel> Items { get; } = new ObservableCollection<ItemViewModel>();

        public ObservableCollection<CategorySummaryViewModel> Summaries { get; } =
            new ObservableCollection<CategorySummaryViewModel>();

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            LoadItemsCommand = new Command(async () => await LoadItems());
        }

        private async Task LoadItems()
        {
            var items = await _dataStore.GetItemsAsync();

            var sums = items
                .GroupBy(x => x.Category)
                .Select(x =>
                    new CategorySummaryViewModel(
                        x.Key.ToString(),
                        x.Sum(y => y.Quantity)));

            foreach (var sum in sums) Summaries.Add(sum);

            foreach (var item in items) Items.Add(new ItemViewModel(item));
        }
    }
}