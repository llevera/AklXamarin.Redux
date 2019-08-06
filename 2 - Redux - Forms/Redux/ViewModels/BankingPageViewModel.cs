using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using Redux.Services;
using Redux.Models;
using System.Collections.Generic;
using Redux.Props;
using Redux.Store;
using System.Collections.Immutable;

namespace Redux.ViewModels
{
    public class BankingPageViewModel : BaseViewModel
    {
        private readonly Store.Store _reduxStore;

        public BankingPageProps Props = BankingPageProps.Default;
        public ImmutableArray<AccountProps> Accounts => Props.Accounts;
        public ImmutableArray<TotalProps> Totals => Props.Totals;

        public BankingPageViewModel()
        {
            _reduxStore = new Store.Store();
            _reduxStore.StateChanged += ReduxStoreOnStateChanged;
        }

        private void ReduxStoreOnStateChanged(State newState)
        {
            Props = new BankingPagePropsMapper().MapState(newState, _reduxStore);
            OnPropertyChanged(nameof(Accounts));
            OnPropertyChanged(nameof(Totals));
        }

        public void LoadAccounts()
        {
            _reduxStore.Dispatch(new LoadAction());
        }
    }
}