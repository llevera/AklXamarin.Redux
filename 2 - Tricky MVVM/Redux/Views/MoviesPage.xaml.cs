using System.ComponentModel;
using Redux.ViewModels;
using Xamarin.Forms;

namespace Redux.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MoviesPage : ContentPage
    {
        private readonly MoviesPageViewModel _viewModel;

        public MoviesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MoviesPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadCommand.Execute(null);
        }
    }
}