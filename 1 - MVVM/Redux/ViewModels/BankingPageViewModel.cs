using System.Collections.Generic;
using System.Linq;
using Redux.Models;
using Redux.Services;

namespace Redux.ViewModels
{
    public class BankingPageViewModel : BaseViewModel
    {
        private readonly IDataStore _dataStore = new MockDataStore();
        private IList<Account> _accounts;

        public List<AccountViewModel> Accounts { get; private set; } = new List<AccountViewModel>();

        public List<TotalViewModel> Totals { get; private set; } =
            new List<TotalViewModel>();
       
        public void UpdateTotals()
        {
            var totalViewModels =
                _accounts
                    .GroupBy(x => x.AccountType)
                    .OrderByDescending(x => x.Sum(y => y.Balance))
                    .Select(
                        x => new TotalViewModel(
                            x.Key,
                            x.Sum(y => y.Balance)));

            Totals = totalViewModels.ToList();
            OnPropertyChanged(nameof(Totals));
        }

        public void LoadAccounts()
        {
            _accounts = _dataStore.GetAccounts().ToList();

            Accounts =
                _accounts.Select(
                    x => new AccountViewModel(
                        account: x,
                        bankingPageViewModel: this))
                    .OrderBy(x => x.Name).ToList(); ;

            OnPropertyChanged(nameof(Accounts));
            UpdateTotals();
        }
    }
}