using System;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class CategorySummaryViewModel : BaseViewModel
    {
        public CategorySummaryViewModel(string categoryLabel, int categoryQuantity, ItemCategory itemCategory)
        {
            CategoryLabel = categoryLabel + ": ";
            CategoryQuantity = categoryQuantity;
            _itemCategory = itemCategory;
        }

        private readonly ItemCategory _itemCategory;

        public string CategoryLabel { get; }
        public int CategoryQuantity { get; }

        public Color TextColor
        {
            get
            {
                switch (_itemCategory)
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