using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using Redux.Models;
using Redux.Props;
using Redux.Services;

namespace Redux.Store
{
    public class Reducer : IReducer
    {
        private readonly IDataStore _dataStore;

        public Reducer(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public State Reduce(State state, IAction action)
        {
            switch (action)
            {
                case LoadAction _:
                {
                    return new State(movies: _dataStore.GetMovies().ToImmutableArray());
                }

                case UpvoteAction upvoteAction:
                {
                    return ChangeVote(title: upvoteAction.Title, change: 1);
                }
                case DownvoteAction downvoteAction:
                {
                    return ChangeVote(title: downvoteAction.Title, change: -1);
                }

                default:
                {
                    throw new InvalidOperationException();
                }
            }

            State ChangeVote(string title, int change)
            {
                var movies = state.Movies;

                var oldMovie = movies.Single(x => x.Title == title);
                var newMovie = new Movie(oldMovie.Title, oldMovie.Votes + change, oldMovie.Genre);

                return new State(movies.Replace(oldMovie, newMovie));
            }
        }
    }
}