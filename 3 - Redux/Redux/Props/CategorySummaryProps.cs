using System;

namespace Redux.Props
{
    public class CategorySummaryProps
    {
        public CategorySummaryProps(string categoryLabel, int categoryQuantity)
        {
            CategoryLabel = categoryLabel;
            CategoryQuantity = categoryQuantity;
        }

        public string CategoryLabel { get; }
        public int CategoryQuantity { get; }
    }
}