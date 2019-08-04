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

        public MoviesPageViewModel()
        {
            LoadCommand = new Command(LoadMovies);
        }

        public ObservableCollection<MovieViewModel> Movies { get; } = new ObservableCollection<MovieViewModel>();

        public ObservableCollection<GenreViewModel> Genres { get; } =
            new ObservableCollection<GenreViewModel>();

        public Command LoadCommand { get; }

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

            Genres.Clear();

            foreach (var genre in genreViewModels)
            {
                Genres.Add(genre);
            }
        }

        private void LoadMovies()
        {
            _movies = _dataStore.GetMovies().ToList();

            var movieViewModels =
                _movies.Select(x => new MovieViewModel(x, this))
                    .OrderBy(x => x.Title);

            Movies.Clear();

            foreach (var item in movieViewModels)
            {
                Movies.Add(item);
            }

            UpdateGenres();
        }
    }
}