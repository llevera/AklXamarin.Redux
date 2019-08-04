using System;
using System.Linq;
using Redux.Models;
using Redux.Props;
using System.Collections.Immutable;

namespace Redux.Store
{
    public class ItemsPropsMapper
    {
        public ItemsProps MapState(State state, Store store)
        {
            var summaryProps =
                state
                    .Items
                    .GroupBy(x => x.Category)
                    .Select(x =>
                        new CategorySummaryProps(x.Key.ToString(), x.Sum(y => y.Quantity), GetTextColour(x.Key)))
                    .ToImmutableArray();

            var itemProps = state.Items.Select(
                x => new ItemProps(
                    x.Text,
                    x.Quantity,
                    GetTextColour(x.Category),
                    (quantity) => store.Dispatch(new ChangeQuantityAction(x.Text, quantity))
                )).ToImmutableArray();

            return new ItemsProps(itemProps, summaryProps);

            Colour GetTextColour(ItemCategory category)
            {
                switch (category)
                {
                    case ItemCategory.Fruit:
                        return new Colour(255, 200, 100);
                    case ItemCategory.Vegetable:
                        return new Colour(0, 255, 0);
                    case ItemCategory.Meat:
                        return new Colour(255, 0, 0);
                    default:
                        return new Colour(200, 200, 200);
                }
            }
        }
    }
}