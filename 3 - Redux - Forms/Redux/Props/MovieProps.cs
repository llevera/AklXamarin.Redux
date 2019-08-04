using System;
using System.Windows.Input;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.Props
{
    public class MovieProps
    {
        public MovieProps(string title, int votes, Color textColor, Action didUpvote, Action didDownvote)
        {
            Title = title;
            Votes = votes;
            TextColor = textColor;
            UpvoteCommand = new Command(didUpvote);
            DownvoteCommand = new Command(didDownvote);
        }

        public string Title { get; }
        public int Votes { get; }
        
        public Color TextColor { get; }

        public ICommand UpvoteCommand { get; }
        public ICommand DownvoteCommand { get; }
    }
}