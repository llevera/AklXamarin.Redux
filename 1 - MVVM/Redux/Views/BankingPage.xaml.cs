using System.ComponentModel;
using Redux.ViewModels;
using Xamarin.Forms;

namespace Redux.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class BankingPage : ContentPage
    {
        private readonly BankingPageViewModel _viewModel;

        public BankingPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new BankingPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadAccounts();
        }
    }
}