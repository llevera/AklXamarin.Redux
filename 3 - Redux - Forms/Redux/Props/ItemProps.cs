using System;
using System.Windows.Input;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.Props
{
    public class ItemProps
    {
        public ItemProps(string text, int quantity, Color textColor, Action<string> didChangeQuantity)
        {
            Text = text;
            Quantity = quantity;
            TextColor = textColor;
            QuantityChangedCommand = new Command<string>(didChangeQuantity);
        }

        public string Text { get; }
        public int Quantity { get; }
        public Color TextColor { get; }
        public Action DidChangeQuantity { get; }

        public ICommand QuantityChangedCommand { get; }
    }
}