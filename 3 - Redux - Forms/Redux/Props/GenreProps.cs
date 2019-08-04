using System;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.Props
{
    public class GenreProps
    {
        public GenreProps(string text, int votes, Color textColor, bool showVotes)
        {
            Text = text;
            Votes = votes;
            TextColor = textColor;
            ShowVotes = showVotes;
        }

        public string Text { get; }
        
        public int Votes { get; }
        
        public Color TextColor { get; }
        
        public bool ShowVotes { get; }
    }
}