using System;
using Xamarin.Forms;

namespace Redux.Props
{
    public class CategorySummaryProps
    {
        public CategorySummaryProps(string categoryLabel, int categoryQuantity, Color textColor)
        {
            CategoryLabel = categoryLabel;
            CategoryQuantity = categoryQuantity;
            TextColor = textColor;
        }

        public string CategoryLabel { get; }
        public int CategoryQuantity { get; }
        public Color TextColor { get; }
    }
}