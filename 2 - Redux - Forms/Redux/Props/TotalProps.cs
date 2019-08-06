using System;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.Props
{
    public class TotalProps
    {
        public TotalProps(string text, string sum, Color textColor)
        {
            Text = text;
            Sum = sum;
            TextColor = textColor;
        }

        public string Text { get; }
        
        public string Sum { get; }
        
        public Color TextColor { get; }
        
    }
}