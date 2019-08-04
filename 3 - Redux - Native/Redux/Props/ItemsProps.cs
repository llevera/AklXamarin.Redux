using System.Collections.Immutable;

namespace Redux.Props
{
    public class ItemsProps
    {
        public ImmutableArray<ItemProps> Items;
        public ImmutableArray<CategorySummaryProps> CategorySummaries;

        public ItemsProps(ImmutableArray<ItemProps> items,
            ImmutableArray<CategorySummaryProps> categorySummaryProps)
        {
            Items = items;
            CategorySummaries = categorySummaryProps;
        }
    }
}