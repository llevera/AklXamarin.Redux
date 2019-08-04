using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Redux.Models;
using Redux.Services;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class MoviesPageViewModel : BaseViewModel
    {
        private readonly IDataStore _dataStore = new MockDataStore();
        private IList<Movie> _movies;


        public List<MovieViewModel> Movies { get; private set; } = new List<MovieViewModel>();

        public List<GenreViewModel> Genres { get; private set; } =
            new List<GenreViewModel>();
       
        public void UpdateGenres()
        {
            var genreViewModels =
                _movies
                    .GroupBy(x => x.Genre)
                    .Select(
                        x => new GenreViewModel(
                            x.Key,
                            x.Sum(y => y.Votes)))
                    .OrderByDescending(x => x.Votes);

            Genres = genreViewModels.ToList();
            OnPropertyChanged(nameof(Genres));
        }

        public void LoadMovies()
        {
            _movies = _dataStore.GetMovies().ToList();

            var movieViewModels =
                _movies.Select(x => new MovieViewModel(x, this))
                    .OrderBy(x => x.Title);

            Movies = movieViewModels.ToList();
            OnPropertyChanged(nameof(Movies));

            UpdateGenres();
        }
    }
}