using System.Collections.Immutable;
using System.Linq;
using Redux.Store;
using Xamarin.Forms;

namespace Redux.Props
{
    public class BankingPagePropsMapper
    {
        public BankingPageProps MapState(State state, Store.Store store)
        {
            var accountsProps = state.Accounts.Select(
                    x => new AccountProps(
                        name: x.Name,
                        balance: x.Balance.ToString("c"),
                        textColor: GetTextColor(balance: x.Balance),
                        didDeposit: () => store.Dispatch(new DepositAction(title: x.Name)),
                        didWithdraw: () => store.Dispatch(new WithdrawAction(title: x.Name))
                    )).OrderBy(x => x.Name)
                .ToImmutableArray();

            var totalsProps =
                state.Accounts
                    .GroupBy(x => x.AccountType)
                    .OrderByDescending(x => x.Sum(selector: y => y.Balance))
                    .Select(
                        x => new TotalProps(
                            text: x.Key.ToString(),
                            sum: x.Sum(selector: y => y.Balance).ToString("c"),
                            textColor: GetTextColor(balance: x.Sum(selector: y => y.Balance))))
                    .ToImmutableArray();

            return new BankingPageProps(
                accounts: accountsProps, 
                totals: totalsProps
            );

            Color GetTextColor(int balance)
            {
                if (balance < 0)
                {
                    return Color.OrangeRed;
                }

                return Color.DimGray;
            }
        }
    }
}