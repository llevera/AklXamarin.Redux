namespace Redux.Store
{
    public class UpvoteAction : IAction
    {
        public string Title { get; }

        public UpvoteAction(string title)
        {
            Title = title;
        }
    }
}