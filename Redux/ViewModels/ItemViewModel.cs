using System;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        private readonly Item _item;
        private int _quantity;

        public ItemViewModel(Item item)
        {
            _item = item;
            Quantity = item.Quantity;
        }

        public string Text => _item.Text;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(TextColor));
            }
        }

        public Color TextColor
        {
            get
            {
                if (Quantity < 1)
                {
                    return Color.Gray;
                }

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
