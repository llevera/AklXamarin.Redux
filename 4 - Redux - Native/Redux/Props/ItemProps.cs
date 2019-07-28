using System;
using System.Windows.Input;
using Redux.Models;

namespace Redux.Props
{
    public class ItemProps
    {
        public ItemProps(string text, int quantity, Color textColor, Action<string> didChangeQuantity)
        {
            Text = text;
            Quantity = quantity;
            TextColor = textColor;
            DidChangeQuantity = didChangeQuantity;
        }

        public string Text { get; }
        public int Quantity { get; }
        public Color TextColor { get; }
        public Action<string> DidChangeQuantity { get; }
    }

    public struct Color
    {
        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public int R;
        public int G;
        public int B;
    }
}