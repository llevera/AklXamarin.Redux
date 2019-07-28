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
                    .Select(x => new CategorySummaryProps(x.Key.ToString(), x.Sum(y => y.Quantity))).ToImmutableArray();

            var itemProps = state.Items.Select(
                x => new ItemProps(
                    x.Text,
                    x.Quantity,
                    GetTextColor(x),
                    (quantity) => store.Dispatch(new ChangeQuantityAction(x.Text, quantity))
                )).ToImmutableArray();

            return new ItemsProps("Shopping", itemProps, summaryProps);

            Color GetTextColor(Item item)
            {
                if (item.Quantity < 1) return new Color(200, 200, 200);

                switch (item.Category)
                {
                    case ItemCategory.Fruit:
                        return new Color(255, 200, 100);
                    case ItemCategory.Vegetable:
                        return new Color(0, 255, 0);
                    case ItemCategory.Meat:
                        return new Color(255, 0, 0);
                    default:
                        return new Color(200, 200, 200);
                }
            }
        }
    }
}