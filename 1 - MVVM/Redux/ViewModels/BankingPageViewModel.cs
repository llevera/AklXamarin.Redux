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

        public string GrandTotalString => _grandTotal.ToString("c");

        private int _grandTotal;
        
        public Color TextColor
        {
            get
            {
                if (_grandTotal < 0)
                    return Color.OrangeRed;
                return Color.DimGray;
            }
        }
       
        public void UpdateAccountTypeSums()
        {
            var accountTypeSumsVewModels =
                _accounts
                    .GroupBy(x => x.AccountType)
                    .Select(
                        x => new AccountTypeSumViewModel(
                            x.Key,
                            x.Sum(y => y.Balance)))
                    .OrderByDescending(x => x.Sum);

            _grandTotal = accountTypeSumsVewModels.Sum(x => x.Sum);
            OnPropertyChanged(nameof(GrandTotalString));
            OnPropertyChanged(nameof(TextColor));

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