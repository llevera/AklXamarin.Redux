using System;
namespace Redux.ViewModels
{
    public class CategorySummary : BaseViewModel
    {
        public CategorySummary(string categoryLabel, int categoryQuantity)
        {
            CategoryLabel = categoryLabel + ": ";
            CategoryQuantity = categoryQuantity;
        }

        public string CategoryLabel { get; set; }
        public int CategoryQuantity { get; set; }
    }
}
