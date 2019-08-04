using System;
using System.Windows.Input;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.Props
{
    public class AccountProps
    {
        public AccountProps(string name, string balance, Color textColor, Action didDeposit, Action didWithdraw)
        {
            Name = name;
            Balance = balance;
            TextColor = textColor;
            DepositCommand = new Command(didDeposit);
            WithdrawCommand = new Command(didWithdraw);
        }

        public string Name { get; }
        
        public string Balance { get; }

        public Color TextColor { get; }

        public ICommand DepositCommand { get; }
        
        public ICommand WithdrawCommand { get; }
    }
}