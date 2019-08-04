using System;
using System.Windows.Input;
using Redux.Models;

namespace Redux.Props
{
    public class ItemProps
    {
        public ItemProps(string text, int quantity, Colour textColour, Action<string> didChangeQuantity)
        {
            Text = text;
            Quantity = quantity;
            TextColour = textColour;
            DidChangeQuantity = didChangeQuantity;
        }

        public string Text { get; }
        public int Quantity { get; }
        public Colour TextColour { get; }
        public Action<string> DidChangeQuantity { get; }
    }
}