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

        int _categoryQuantity;
        public int CategoryQuantity
        {
            get
            {
                return _categoryQuantity;
            }
            set
            {
                _categoryQuantity = value;
                OnPropertyChanged(nameof(CategoryQuantity));
            }
        }
    }
}
