using Redux.Models;
using Redux.Store;

namespace Redux.Props
{
    public class ChangeQuantityAction : IAction
    {
        private readonly string _text;
        private readonly string _quantity;

        public ChangeQuantityAction(string text, string quantity)
        {
            _text = text;
            _quantity = quantity;
        }

        public State Reduce(State state)
        {
            var items = state.Items;

            foreach (var item in items)
                if (_text == item.Text)
                    if (int.TryParse(_quantity, out var intQuantity))
                        item.Quantity = intQuantity;

            return new State(items);
        }
    }
}