namespace Redux.Store
{
    public class WithdrawAction : IAction
    {
        public WithdrawAction(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}