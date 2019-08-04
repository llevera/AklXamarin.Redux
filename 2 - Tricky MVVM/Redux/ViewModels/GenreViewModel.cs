using Redux.Models;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class GenreViewModel : BaseViewModel
    {
        private readonly Genre _genre;

        private int _genreUpvotes;

        public GenreViewModel(Genre genre, int votes)
        {
            _genre = genre;
            Votes = votes;
        }

        public string Text => _genre.ToString();

        public bool ShowVotes => Votes != 0;

        public int Votes
        {
            get => _genreUpvotes;
            set
            {
                _genreUpvotes = value;
                OnPropertyChanged(nameof(Votes));
            }
        }

        public Color TextColor
        {
            get
            {
                if (Votes < 0)
                    return Color.OrangeRed;
                return Color.DimGray;
            }
        }
    }
}