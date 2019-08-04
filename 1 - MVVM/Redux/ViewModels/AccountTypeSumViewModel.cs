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
            _sum = sum;
        }

        public string Text => _accountType.ToString();

        private int _sum;

        public string Sum => _sum.ToString("c");
 
        public Color TextColor
        {
            get
            {
                if (_sum < 0)
                    return Color.OrangeRed;
                return Color.DimGray;
            }
        }
    }
}