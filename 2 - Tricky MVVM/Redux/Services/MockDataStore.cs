using System.Collections.Generic;
using Redux.Models;

namespace Redux.Services
{
    public class MockDataStore : IDataStore
    {
        private readonly List<Movie> _items;

        public MockDataStore()
        {
            _items = new List<Movie>(new[]
            {
                new Movie {Title = "The Godfather", Genre = Genre.Drama},
                new Movie {Title = "Shawshank Redemption", Genre = Genre.Drama},
                new Movie {Title = "The Dark Night", Genre = Genre.Action},
                new Movie {Title = "Alien", Genre = Genre.Horror},
                new Movie {Title = "Terminator 2", Genre = Genre.Action},
                new Movie {Title = "Office Space", Genre = Genre.Comedy}
            });
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _items;
        }
    }
}