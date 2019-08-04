using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Redux.Models;
using Redux.Services;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class BankingPageViewModel : BaseViewModel
    {
        private readonly IDataStore _dataStore = new MockDataStore();
        private IList<Account> _accounts;

        public List<AccountViewModel> Accounts { get; private set; } = new List<AccountViewModel>();

        public List<AccountTypeSumViewModel> AccountTypeSums { get; private set; } =
            new List<AccountTypeSumViewModel>();
       
        public void UpdateAccountTypeSums()
        {
            var accountTypeSumsVewModels =
                _accounts
                    .GroupBy(x => x.AccountType)
                    .OrderByDescending(x => x.Sum(y => y.Balance))
                    .Select(
                        x => new AccountTypeSumViewModel(
                            x.Key,
                            x.Sum(y => y.Balance)));

            AccountTypeSums = accountTypeSumsVewModels.ToList();
            OnPropertyChanged(nameof(AccountTypeSums));
        }

        public void LoadAccounts()
        {
            _accounts = _dataStore.GetMovies().ToList();

            var accountViewModels =
                _accounts.Select(x => new AccountViewModel(account: x, bankingPageViewModel: this))
                    .OrderBy(x => x.Name);

            Accounts = accountViewModels.ToList();
            OnPropertyChanged(nameof(Accounts));

            UpdateAccountTypeSums();
        }
    }
}