using Redux.Models;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class AccountTypeSumViewModel : BaseViewModel
    {
        private readonly AccountType _accountType;

        public AccountTypeSumViewModel(AccountType accountType, int sum)
        {
            _accountType = accountType;
            Sum = sum;
        }

        public string Text => _accountType.ToString();

        public int Sum { get; }

        public string SumString => Sum.ToString("c");
 
        public Color TextColor
        {
            get
            {
                if (Sum < 0)
                    return Color.OrangeRed;
                return Color.DimGray;
            }
        }
    }
}