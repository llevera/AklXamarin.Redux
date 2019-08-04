namespace Redux.Store
{
    public class DownvoteAction : IAction
    {
        public string Title { get; }

        public DownvoteAction(string title)
        {
            Title = title;
        }
    }
}