using Redux.Models;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        private readonly Movie _movie;
        private readonly MoviesPageViewModel _moviesPageViewModel;

        public MovieViewModel(Movie movie, MoviesPageViewModel moviesPageViewModel)
        {
            _movie = movie;
            _moviesPageViewModel = moviesPageViewModel;
            UpvoteCommand = new Command(Upvote);
            DownvoteCommand = new Command(Downvote);
        }

        public Command UpvoteCommand { get; }

        public Command DownvoteCommand { get; }

        public string Title => _movie.Title;

        public string Votes => _movie.Votes.ToString();

        public bool ShowVotes => _movie.Votes != 0;

        public Color TextColor
        {
            get
            {
                if (_movie.Votes < 0)
                    return Color.OrangeRed;
                return Color.DimGray;
            }
        }

        private void Upvote()
        {
            _movie.Votes++;
            OnPropertyChanged(nameof(Votes));
            OnPropertyChanged(nameof(TextColor));
            OnPropertyChanged(nameof(ShowVotes));
            _moviesPageViewModel.UpdateGenres();
        }

        private void Downvote()
        {
            _movie.Votes--;
            OnPropertyChanged(nameof(Votes));
            OnPropertyChanged(nameof(TextColor));
            OnPropertyChanged(nameof(ShowVotes));
            _moviesPageViewModel.UpdateGenres();
        }
    }
}