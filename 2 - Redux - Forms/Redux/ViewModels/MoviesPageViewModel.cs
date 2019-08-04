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

        private MoviesPageProps _props = MoviesPageProps.Default;
        public ImmutableArray<MovieProps> Movies => _props.Movies;
        public ImmutableArray<GenreProps> Genres => _props.Genres;

        public MoviesPageViewModel()
        {
            _reduxStore = new Store.Store();
            _reduxStore.StateChanged += ReduxStoreOnStateChanged;
        }

        private void ReduxStoreOnStateChanged(State newState)
        {
            _props = new MoviesPropsMapper().MapState(newState, _reduxStore);
            OnPropertyChanged(nameof(Movies));
            OnPropertyChanged(nameof(Genres));
        }

        public void LoadMovies()
        {
            _reduxStore.Dispatch(new LoadAction());
        }
    }
}