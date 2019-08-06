using System;
using System.Collections.Immutable;
using Foundation;
using Redux.Props;
using Redux.Store;
using UIKit;

namespace Redux.iOS
{
    public partial class BankingPageViewController : UIViewController
    {
        private readonly Store.Store _store = new Store.Store();
        private UITableView _accountsTable;
        private UITableView _totalsTable;

        public BankingPageViewController() : base("BankingPageViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _totalsTable = new UITableView();
            _totalsTable.RegisterClassForCellReuse(typeof(TotalViewCell),
                "Totals");

            _totalsTable.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(_totalsTable);

            _totalsTable.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, 12).Active = true;
            _totalsTable.LeftAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeftAnchor, 12).Active = true;
            _totalsTable.RightAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.RightAnchor, -12).Active = true;
            _totalsTable.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.CenterYAnchor, -12).Active = true;

            _accountsTable = new UITableView();
            _accountsTable.RegisterClassForCellReuse(typeof(AccountViewCell),
                "Accounts");

            _accountsTable.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(_accountsTable);

            _accountsTable.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.CenterYAnchor, 12).Active = true;
            _accountsTable.LeftAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeftAnchor, 12).Active = true;
            _accountsTable.RightAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.RightAnchor, -12).Active = true;
            _accountsTable.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor, -12).Active = true;

            _totalsTable.HeightAnchor.ConstraintEqualTo(_accountsTable.HeightAnchor);

            _store.StateChanged += OnStateChanged;

            _store.Dispatch(new LoadAction());
        }

        private void OnStateChanged(State state)
        {
            var props = new BankingPagePropsMapper().MapState(state, _store);
            _accountsTable.DataSource = new AccountsDataSource(props.Accounts);
            _accountsTable.ReloadData();
            _totalsTable.DataSource = new TotalsDataSource(props.Totals);
            _totalsTable.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    public class AccountsDataSource : UITableViewDataSource
    {
        private readonly ImmutableArray<AccountProps> _props;

        public AccountsDataSource(ImmutableArray<AccountProps> props)
        {
            _props = props;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (AccountViewCell)
                tableView.DequeueReusableCell("Accounts", indexPath);
            cell.SetProps(_props[indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _props.Length;
        }
    }

    public class AccountViewCell : UITableViewCell
    {
        private readonly UILabel _accountLabel;
        private readonly UILabel _balance;
        private readonly UIButton _depositButton;
        private readonly UIButton _withdrawButton;

        private AccountProps _props;

        public AccountViewCell(IntPtr handle) : base(handle)
        {
            _accountLabel = new UILabel();
            _accountLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            AddSubview(_accountLabel);
            _accountLabel.LeftAnchor.ConstraintEqualTo(LeftAnchor, 12).Active = true;
            _accountLabel.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;

            _balance = new UILabel();
            _balance.TranslatesAutoresizingMaskIntoConstraints = false;
            AddSubview(_balance);
            _balance.TextAlignment = UITextAlignment.Right;
            _balance.WidthAnchor.ConstraintEqualTo(100).Active = true;
            _balance.RightAnchor.ConstraintEqualTo(RightAnchor, -12).Active = true;
            _balance.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;

            _withdrawButton = new UIButton();
            _withdrawButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            _withdrawButton.SetTitle("↑", UIControlState.Normal);
            _withdrawButton.TranslatesAutoresizingMaskIntoConstraints = false;
            AddSubview(_withdrawButton);
            _withdrawButton.RightAnchor.ConstraintEqualTo(_balance.LeftAnchor, 12).Active = true;
            _withdrawButton.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;

            _depositButton = new UIButton();
            _depositButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            _depositButton.SetTitle("↓", UIControlState.Normal);
            _depositButton.TranslatesAutoresizingMaskIntoConstraints = false;
            AddSubview(_depositButton);
            _depositButton.RightAnchor.ConstraintEqualTo(_withdrawButton.LeftAnchor, 12).Active = true;
            _depositButton.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;

            _depositButton.TouchDown += delegate { _props.DidDeposit(); };

            _withdrawButton.TouchDown += delegate { _props.DidWithdraw(); };
        }

        public void SetProps(AccountProps props)
        {
            _props = props;
            _accountLabel.Text = _props.Name;

            _balance.Text = _props.Balance;
            _balance.TextColor = UIColor.FromRGB(_props.TextColor.R, _props.TextColor.G, _props.TextColor.B);
        }
    }

    public class TotalsDataSource : UITableViewDataSource
    {
        private readonly ImmutableArray<TotalProps> _props;

        public TotalsDataSource(ImmutableArray<TotalProps> props)
        {
            _props = props;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (TotalViewCell)
                tableView.DequeueReusableCell("Totals", indexPath);
            cell.SetProps(_props[indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _props.Length;
        }
    }

    public class TotalViewCell : UITableViewCell
    {
        private readonly UILabel _balance;
        private readonly UILabel _text;

        public TotalViewCell(IntPtr handle) : base(handle)
        {
            _text = new UILabel();
            _text.TranslatesAutoresizingMaskIntoConstraints = false;
            AddSubview(_text);
            _text.LeftAnchor.ConstraintEqualTo(LeftAnchor, 12).Active = true;
            _text.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;

            _balance = new UILabel();
            _balance.TranslatesAutoresizingMaskIntoConstraints = false;
            _balance.TextAlignment = UITextAlignment.Right;
            _balance.WidthAnchor.ConstraintEqualTo(100).Active = true;
            AddSubview(_balance);
            _balance.RightAnchor.ConstraintEqualTo(RightAnchor, -12).Active = true;
            _balance.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;
        }

        public void SetProps(TotalProps props)
        {
            _text.Text = props.Text;
            _balance.Text = props.Sum;

            _balance.TextColor = UIColor.FromRGB(props.TextColor.R, props.TextColor.G, props.TextColor.B);
        }
    }
}