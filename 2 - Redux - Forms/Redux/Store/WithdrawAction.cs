namespace Redux.Store
{
    public class WithdrawAction : IAction
    {
        public string Title { get; }

        public WithdrawAction(string title)
        {
            Title = title;
        }
    }
}