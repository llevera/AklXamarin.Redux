using System;

namespace Redux.Props
{
    public class AccountProps
    {
        public AccountProps(string name, string balance, Colour textColor, Action didDeposit, Action didWithdraw)
        {
            Name = name;
            Balance = balance;
            TextColor = textColor;
            DidDeposit = didDeposit;
            DidWithdraw = didWithdraw;
        }

        public string Name { get; }

        public string Balance { get; }

        public Colour TextColor { get; }

        public Action DidDeposit { get; }

        public Action DidWithdraw { get; }
    }
}