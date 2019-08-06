using System.Collections.Immutable;
using System.Linq;
using Redux.Store;

namespace Redux.Props
{
    public class BankingPagePropsMapper
    {
        public BankingPageProps MapState(State state, Store.Store store)
        {
            var accountTypeSumProps =
                state.Accounts
                    .GroupBy(x => x.AccountType)
                    .OrderByDescending(x => x.Sum(y => y.Balance))
                    .Select(
                        x => new TotalProps(
                            x.Key.ToString(),
                            x.Sum(y => y.Balance).ToString("c"),
                            GetTextColor(x.Sum(y => y.Balance))))
                    .ToImmutableArray();

            var accountsProps = state.Accounts.Select(
                    x => new AccountProps(
                        x.Name,
                        x.Balance.ToString("c"),
                        GetTextColor(x.Balance),
                        () => store.Dispatch(new DepositAction(x.Name)),
                        () => store.Dispatch(new WithdrawAction(x.Name))
                    )).OrderBy(x => x.Name)
                .ToImmutableArray();

            var grandTotal = state.Accounts.Sum(x => x.Balance);

            return new BankingPageProps(
                accountsProps,
                accountTypeSumProps
            );

            Colour GetTextColor(int balance)
            {
                if (balance < 0) return new Colour(200, 50, 50);

                return new Colour(100, 100, 100);
            }
        }
    }
}