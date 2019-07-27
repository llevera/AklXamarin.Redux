using Redux.Models;
using Redux.Store;

namespace Redux.Props
{
    public class ChangeQuantityAction : IAction
    {
        private readonly ItemCategory _category;
        private readonly string _quantity;

        public ChangeQuantityAction(ItemCategory category, string quantity)
        {
            _category = category;
            _quantity = quantity;
        }
        
        public State Reduce(State state)
        {
            var items = state.Items;

            foreach (var item in items)
            {
                if (_category == item.Category)
                {
                    if (int.TryParse(_quantity, out int intQuantity))
                    {
                        item.Quantity = intQuantity;
                    }
                }
            }

            return new State(items);
        }
    }
}