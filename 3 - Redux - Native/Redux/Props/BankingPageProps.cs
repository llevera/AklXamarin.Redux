using System.Collections.Immutable;

namespace Redux.Props
{
    public class BankingPageProps
    {
        public static BankingPageProps Default = new BankingPageProps(
            ImmutableArray<AccountProps>.Empty,
            ImmutableArray<TotalProps>.Empty
        );

        public BankingPageProps(
            ImmutableArray<AccountProps> accounts,
            ImmutableArray<TotalProps> accountTypeSumProps)
        {
            Accounts = accounts;
            Totals = accountTypeSumProps;
        }

        public ImmutableArray<AccountProps> Accounts { get; }
        public ImmutableArray<TotalProps> Totals { get; }
    }
}