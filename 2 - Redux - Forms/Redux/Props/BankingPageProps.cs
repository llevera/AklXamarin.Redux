using System.Collections.Immutable;
using Xamarin.Forms;

namespace Redux.Props
{
    public class BankingPageProps
    {
        public ImmutableArray<AccountProps> Accounts { get; }
        public ImmutableArray<TotalProps> Totals { get; }

        public BankingPageProps(
            ImmutableArray<AccountProps> accounts,
            ImmutableArray<TotalProps> totals)
        {
            Accounts = accounts;
            Totals = totals;
        }
        

        public static BankingPageProps Default = new BankingPageProps(
            ImmutableArray<AccountProps>.Empty,
            ImmutableArray<TotalProps>.Empty
            );

    }
}