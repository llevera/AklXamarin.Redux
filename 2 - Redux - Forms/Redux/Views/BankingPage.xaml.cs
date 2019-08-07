using System.Collections.Immutable;
using System.ComponentModel;
using Redux.Props;
using Redux.Store;
using Xamarin.Forms;

namespace Redux.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class BankingPage : ContentPage
    {
        private readonly Store.Store _reduxStore = new Store.Store();

        public BankingPageProps Props = BankingPageProps.Default;
        public ImmutableArray<AccountProps> Accounts => Props.Accounts;
        public ImmutableArray<TotalProps> Totals => Props.Totals;

        public BankingPage()
        {
            InitializeComponent();
            _reduxStore.StateChanged += (newState) =>
            {
                ReduxStoreOnStateChanged(newState);
            };

            BindingContext = this;
        }

        private void ReduxStoreOnStateChanged(State newState)
        {
            Props = new BankingPagePropsMapper().MapState(newState, _reduxStore);
            OnPropertyChanged(nameof(Accounts));
            OnPropertyChanged(nameof(Totals));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _reduxStore.Dispatch(new LoadAction());
        }
    }
}