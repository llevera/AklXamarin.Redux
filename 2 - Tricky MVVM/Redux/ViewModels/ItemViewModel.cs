using System;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        private readonly Item _item;
        private readonly ItemsViewModel _itemsViewModel;

        public ItemViewModel(Item item, ItemsViewModel itemsViewModel)
        {
            _item = item;
            _itemsViewModel = itemsViewModel;
        }

        public string Text => _item.Text;

        public int Quantity
        {
            get => _item.Quantity;
            set
            {
                _item.Quantity = value;
                _itemsViewModel.UpdateSummaries();

                OnPropertyChanged(nameof(TextColor));
            }
        }

        public Color TextColor
        {
            get
            {
                if (Quantity < 1) return Color.Gray;

                switch (_item.Category)
                {
                    case ItemCategory.Fruit:
                        return Color.Orange;
                    case ItemCategory.Vegetable:
                        return Color.Green;
                    case ItemCategory.Meat:
                        return Color.Red;
                    default:
                        return Color.Gray;
                }
            }
        }
    }
}