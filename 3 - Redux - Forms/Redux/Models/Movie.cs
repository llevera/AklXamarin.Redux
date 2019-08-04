namespace Redux.Models
{
    public class Movie
    {
        public Movie(string title, int votes, Genre genre)
        {
            Title = title;
            Votes = votes;
            Genre = genre;
        }

        public string Title { get; }
        public int Votes { get; }
        public Genre Genre { get; }
    }
}