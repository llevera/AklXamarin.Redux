using System;
using System.Linq;
using Redux.Models;
using Redux.Props;
using Xamarin.Forms;
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
                    (quantity) => store.Dispatch(new ChangeQuantityAction(x.Category, quantity))
                    )).ToImmutableArray();

            return new ItemsProps("Shopping", itemProps, summaryProps);

            Color GetTextColor(Item item)
            {

                if (item.Quantity < 1)
                {
                    return Color.Gray;
                }

                switch (item.Category)
                {
                    case ItemCategory.Fruit:
                        return Color.Orange;
                    case ItemCategory.Vegetable:
                        return Color.Green;
                    case ItemCategory.Meat:
                        return Color.Red;
                    default:
                        return Color.Gray;
                }
            }
        }
    }
}
