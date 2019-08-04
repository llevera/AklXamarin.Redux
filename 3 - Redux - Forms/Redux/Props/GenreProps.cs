using System;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.Props
{
    public class GenreProps
    {
        public GenreProps(string text, int votes, Color textColor)
        {
            Text = text;
            Votes = votes;
            TextColor = textColor;
        }

        public string Text { get; }
        public int Votes {get; }
        public Color TextColor { get; }
    }
}