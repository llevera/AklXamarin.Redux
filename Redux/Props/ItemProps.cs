using System;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.Props
{
    public class ItemProps 
    {
        public ItemProps(string text, int quantity, Color textColor, Action didChangeQuantity)
        {
            Text = text;
            Quantity = quantity;
            TextColor = textColor;
            DidChangeQuantity = didChangeQuantity;
        }

        public string Text { get; }
        public int Quantity { get; }
        public Color TextColor { get; }
        public Action DidChangeQuantity { get; }
    }
}
