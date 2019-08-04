using System.Collections.Immutable;
using Xamarin.Forms;

namespace Redux.Props
{
    public class BankingPageProps
    {
        public ImmutableArray<AccountProps> Accounts { get; }
        public ImmutableArray<AccountTypeSumProps> AccountTypeSums { get; }

        public BankingPageProps(
            ImmutableArray<AccountProps> accounts,
            ImmutableArray<AccountTypeSumProps> accountTypeSumProps)
        {
            Accounts = accounts;
            AccountTypeSums = accountTypeSumProps;
        }
        

        public static BankingPageProps Default = new BankingPageProps(
            ImmutableArray<AccountProps>.Empty,
            ImmutableArray<AccountTypeSumProps>.Empty
            );

    }
}