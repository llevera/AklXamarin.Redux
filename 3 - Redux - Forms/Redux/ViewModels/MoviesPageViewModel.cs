using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Redux.Services;
using Redux.Models;
using System.Collections.Generic;
using Redux.Props;
using Redux.Store;
using System.Collections.Immutable;

namespace Redux.ViewModels
{
    public class MoviesPageViewModel : BaseViewModel
    {
        private readonly Store.Store _reduxStore;
        private readonly IDataStore _dataStore = new MockDataStore();
        private IList<Movie> _movies;

        public List<MovieProps> Movies { get; private set; } = new List<MovieProps>();

        public List<GenreProps> Genres { get; private set; } =
            new List<GenreProps>();

        public MoviesPageViewModel()
        {
            _reduxStore = new Store.Store();
            _reduxStore.StateChanged += ReduxStoreOnStateChanged;
        }

        private void ReduxStoreOnStateChanged(State newState)
        {
            var props = new MoviesPropsMapper().MapState(newState, _reduxStore);

            Movies = new List<MovieProps>(props.Movies);
            OnPropertyChanged(nameof(Movies));

            Genres = new List<GenreProps>(props.Genres);
            OnPropertyChanged(nameof(Genres));
        }

        public void LoadMovies()
        {
            _reduxStore.Dispatch(new LoadAction());
        }
    }
}