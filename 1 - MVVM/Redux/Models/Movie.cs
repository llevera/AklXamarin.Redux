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
        
        public string Title { get; set; }
        public int Votes { get; set; }
        public Genre Genre { get; set; }
    }
}