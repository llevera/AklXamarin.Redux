using System.Collections.Immutable;
using System.Linq;
using Redux.Store;
using Xamarin.Forms;

namespace Redux.Props
{
    public class MoviesPropsMapper
    {
        public MoviesPageProps MapState(State state, Store.Store store)
        {
            var genreProps =
                state.Movies
                    .GroupBy(x => x.Genre)
                    .Select(
                        x => new GenreProps(
                            text: x.Key.ToString(),
                            votes: x.Sum(selector: y => y.Votes),
                            textColor: GetTextColor(votes: x.Sum(selector: y => y.Votes)),
                            showVotes: x.Sum(selector: y => y.Votes) !=0))
                    .OrderByDescending(x => x.Votes)
                    .ToImmutableArray();

            var movieProps = state.Movies.Select(
                    x => new MovieProps(
                        title: x.Title,
                        votes: x.Votes,
                        textColor: GetTextColor(votes: x.Votes),
                        showVotes: x.Votes !=0,
                        didUpvote: () => store.Dispatch(new UpvoteAction(title: x.Title)),
                        didDownvote: () => store.Dispatch(new DownvoteAction(title: x.Title))
                    )).OrderBy(x => x.Title)
                .ToImmutableArray();

            return new MoviesPageProps(movies: movieProps, genreProps: genreProps);

            Color GetTextColor(int votes)
            {
                if (votes < 0)
                {
                    return Color.OrangeRed;
                }

                return Color.DimGray;
            }
        }
    }
}