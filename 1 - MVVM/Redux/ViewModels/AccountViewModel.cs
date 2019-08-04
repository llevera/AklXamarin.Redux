using Redux.Models;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        private readonly Account _account;
        private readonly BankingPageViewModel _bankingPageViewModel;

        public AccountViewModel(Account account, BankingPageViewModel bankingPageViewModel)
        {
            _account = account;
            _bankingPageViewModel = bankingPageViewModel;
            DepositCommand = new Command(Deposit);
            WithdrawCommand = new Command(Withdraw);
        }

        public Command DepositCommand { get; }

        public Command WithdrawCommand { get; }

        public string Name => _account.Name;

        public string Balance => _account.Balance.ToString("c");

        public Color TextColor
        {
            get
            {
                if (_account.Balance < 0)
                    return Color.OrangeRed;
                return Color.DimGray;
            }
        }

        private void Deposit()
        {
            _account.Balance+=10;
            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(TextColor));
            _bankingPageViewModel.UpdateAccountTypeSums();
        }

        private void Withdraw()
        {
            if (_account.AccountType == AccountType.Credit ||
                _account.Balance - 10 >= 0)
            {
                _account.Balance -= 10;
            }

            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(TextColor));
            _bankingPageViewModel.UpdateAccountTypeSums();
        }
    }
}