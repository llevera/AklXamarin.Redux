using System.Linq;
using Redux.Models;
using Redux.Store;

namespace Redux.Props
{
    public class UpvoteAction : IAction
    {
        private readonly string _title;

        public UpvoteAction(string title)
        {
            _title = title;
        }

        public State Reduce(State state)
        {
            var movies = state.Movies;

            var oldMovie = movies.Single(x => x.Title == _title);
            var newMovie = new Movie(oldMovie.Title, oldMovie.Votes + 1, oldMovie.Genre);

            return new State(
                movies.Replace(oldMovie, newMovie));
        }
    }
}