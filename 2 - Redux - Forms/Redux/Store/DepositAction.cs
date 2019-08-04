namespace Redux.Store
{
    public class DepositAction : IAction
    {
        public string Title { get; }

        public DepositAction(string title)
        {
            Title = title;
        }
    }
}