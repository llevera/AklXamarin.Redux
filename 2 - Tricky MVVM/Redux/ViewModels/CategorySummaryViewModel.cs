using System;

namespace Redux.ViewModels
{
    public class CategorySummaryViewModel : BaseViewModel
    {
        public CategorySummaryViewModel(string categoryLabel, int categoryQuantity)
        {
            CategoryLabel = categoryLabel + ": ";
            CategoryQuantity = categoryQuantity;
        }

        public string CategoryLabel { get; set; }

        private int _categoryQuantity;

        public int CategoryQuantity
        {
            get => _categoryQuantity;
            set
            {
                _categoryQuantity = value;
                OnPropertyChanged(nameof(CategoryQuantity));
            }
        }
    }
}