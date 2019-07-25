using Redux.Models;
using Redux.Store;

namespace Redux.Props
{
    public class ChangeQuantityAction : IAction
    {
        private readonly ItemCategory _category;
        private readonly int _quantity;

        public ChangeQuantityAction(ItemCategory category, int quantity)
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
                    item.Quantity = _quantity;
                }
            }

            return new State(items);
        }
    }
}