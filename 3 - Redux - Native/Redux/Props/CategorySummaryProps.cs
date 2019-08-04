using System;

namespace Redux.Props
{
    public class CategorySummaryProps
    {
        public CategorySummaryProps(string categoryLabel, int categoryQuantity, Colour textColour)
        {
            CategoryLabel = categoryLabel;
            CategoryQuantity = categoryQuantity;
            TextColour = textColour;
        }

        public string CategoryLabel { get; }
        public int CategoryQuantity { get; }
        public Colour TextColour { get; }
    }
}