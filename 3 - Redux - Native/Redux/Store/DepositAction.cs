namespace Redux.Store
{
    public class DepositAction : IAction
    {
        public DepositAction(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}