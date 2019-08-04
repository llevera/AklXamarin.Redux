using System;
using System.Linq;
using Redux.Models;
using Redux.Props;
using Xamarin.Forms;
using System.Collections.Immutable;

namespace Redux.Store
{
    public class MoviesPropsMapper
    {
        public MoviesPageProps MapState(State state, Store store)
        {
            var genreProps =
                state.Movies
                    .GroupBy(x => x.Genre)
                    .Select(
                        x => new GenreProps(
                            x.Key.ToString(),
                            x.Sum(y => y.Votes),
                            GetTextColor(x.Sum(y => y.Votes))
                            ))
                    .OrderByDescending(x => x.Votes)
                    .ToImmutableArray();
                ;
            
            var movieProps = state.Movies.Select(
                x => new MovieProps(
                    x.Title,
                    x.Votes,
                    GetTextColor(x.Votes),
                    () => store.Dispatch(new UpvoteAction(x.Title)),
                    () => store.Dispatch(new DownvoteAction(x.Title))

                )).OrderBy(x => x.Title)
                .ToImmutableArray();

            return new MoviesPageProps(movieProps, genreProps);

            Color GetTextColor(int votes)
            {
                if (votes < 0)
                    return Color.OrangeRed;
                return Color.DimGray;
            }
        }
    }
}