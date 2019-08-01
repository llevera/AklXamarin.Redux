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
                    .Select(x => new CategorySummaryProps(x.Key.ToString(), x.Sum(y => y.Quantity), GetTextColor(x.Key))).ToImmutableArray();

            var itemProps = state.Items.Select(
                x => new ItemProps(
                    x.Text,
                    x.Quantity,
                    GetTextColor(x.Category),
                    (quantity) => store.Dispatch(new ChangeQuantityAction(x.Text, quantity))
                )).ToImmutableArray();

            return new ItemsProps(itemProps, summaryProps);

            Color GetTextColor(ItemCategory category)
            {
                switch (category)
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