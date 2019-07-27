using System.Collections.Immutable;

namespace Redux.Props
{
    public class ItemsProps
    {
        public string Title { get; }
        public ImmutableArray<ItemProps> Items;
        public ImmutableArray<CategorySummaryProps> CategorySummaries;

        public ItemsProps(string title, ImmutableArray<ItemProps> items,
            ImmutableArray<CategorySummaryProps> categorySummaryProps)
        {
            Title = title;
            Items = items;
            CategorySummaries = categorySummaryProps;
        }
    }
}