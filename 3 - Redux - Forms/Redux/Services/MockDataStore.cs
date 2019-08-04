using System.Collections.Generic;
using Redux.Models;

namespace Redux.Services
{
    public class MockDataStore : IDataStore
    {
        private readonly List<Movie> _movies;

        public MockDataStore()
        {
            _movies = new List<Movie>(new[]
            {
                new Movie("The Godfather",0, Genre.Drama),
                new Movie("Shawshank Redemption",0,Genre.Drama),
                new Movie("The Dark Night", 0, Genre.Action),
                new Movie("Alien", 0, Genre.Horror),
                new Movie("Terminator 2", 0, Genre.Action),
                new Movie("Office Space", 0, Genre.Comedy)
            });
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movies;
        }
    }
}