using System;
using System.Collections.Immutable;
using Foundation;
using Redux.Models;
using Redux.Props;
using Redux.Services;
using Redux.Store;
using UIKit;

namespace Redux.iOS
{
    public partial class MainViewController : UIViewController
    {
        private Store.Store _store = new Store.Store();
        private IDataStore<Item> _dataStore => new MockDataStore();
        private UITableView _itemsTable;
        private UITableView _summariesTable;

        public MainViewController() : base("MainViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _summariesTable = new UITableView();
            _summariesTable.RegisterClassForCellReuse(typeof(SummaryViewCell),
                "Summaries");

            _summariesTable.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(_summariesTable);

            _summariesTable.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, 12).Active = true;
            _summariesTable.LeftAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeftAnchor, 12).Active = true;
            _summariesTable.RightAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.RightAnchor, -12).Active = true;
            _summariesTable.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.CenterYAnchor, -12).Active = true;

            _itemsTable = new UITableView();
            _itemsTable.RegisterClassForCellReuse(typeof(ItemViewCell),
                "Items");

            _itemsTable.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(_itemsTable);

            _itemsTable.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.CenterYAnchor, 12).Active = true;
            _itemsTable.LeftAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeftAnchor, 12).Active = true;
            _itemsTable.RightAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.RightAnchor, -12).Active = true;
            _itemsTable.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor, -12).Active = true;

            _summariesTable.HeightAnchor.ConstraintEqualTo(_itemsTable.HeightAnchor);

            _store.StateChanged += OnStateChanged;

            _store.Dispatch(new LoadSaga(_dataStore));
        }

        private void OnStateChanged(State state)
        {
            var props = new ItemsPropsMapper().MapState(state, _store);
            _itemsTable.DataSource = new ItemsDataSource(props.Items);
            _itemsTable.ReloadData();
            _summariesTable.DataSource = new SummaryDataSource(props.CategorySummaries);
            _summariesTable.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    public class ItemsDataSource : UITableViewDataSource
    {
        private ImmutableArray<ItemProps> _props;

        public ItemsDataSource(ImmutableArray<ItemProps> props)
        {
            _props = props;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (ItemViewCell)
                tableView.DequeueReusableCell("Items", indexPath);
            cell.SetProps(_props[indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _props.Length;
        }
    }

    public class ItemViewCell : UITableViewCell
    {
        private UILabel _categoryLabel;
        private UITextField _quantity;

        public ItemViewCell(IntPtr handle) : base(handle)
        {
            _categoryLabel = new UILabel();
            _categoryLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            AddSubview(_categoryLabel);
            _categoryLabel.LeftAnchor.ConstraintEqualTo(LeftAnchor, 12).Active = true;
            _categoryLabel.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;

            _quantity = new UITextField();
            _quantity.TranslatesAutoresizingMaskIntoConstraints = false;
            AddSubview(_quantity);
            _quantity.RightAnchor.ConstraintEqualTo(RightAnchor, -12).Active = true;
            _quantity.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;
        }

        public void SetProps(ItemProps props)
        {
            _categoryLabel.Text = props.Text;
            _categoryLabel.TextColor = UIColor.FromRGB(props.TextColour.R, props.TextColour.G, props.TextColour.B);

            _quantity.Text = props.Quantity.ToString();
            _quantity.EditingDidEnd += delegate(object sender, EventArgs e)
            {
                props.DidChangeQuantity(_quantity.Text);
            };
        }
    }

    public class SummaryDataSource : UITableViewDataSource
    {
        private ImmutableArray<CategorySummaryProps> _props;

        public SummaryDataSource(ImmutableArray<CategorySummaryProps> props)
        {
            _props = props;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (SummaryViewCell)
                tableView.DequeueReusableCell("Summaries", indexPath);
            cell.SetProps(_props[indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _props.Length;
        }
    }

    public class SummaryViewCell : UITableViewCell
    {
        private UILabel _text;
        private UILabel _quantity;

        public SummaryViewCell(IntPtr handle) : base(handle)
        {
            _text = new UILabel();
            _text.TranslatesAutoresizingMaskIntoConstraints = false;
            AddSubview(_text);
            _text.LeftAnchor.ConstraintEqualTo(LeftAnchor, 12).Active = true;
            _text.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;

            _quantity = new UILabel();
            _quantity.TranslatesAutoresizingMaskIntoConstraints = false;
            AddSubview(_quantity);
            _quantity.LeftAnchor.ConstraintEqualTo(_text.RightAnchor, 12).Active = true;
            _quantity.TopAnchor.ConstraintEqualTo(TopAnchor, 12).Active = true;
        }

        public void SetProps(CategorySummaryProps props)
        {
            _text.Text = props.CategoryLabel + ": ";
            _quantity.Text = props.CategoryQuantity.ToString();

            _text.TextColor = UIColor.FromRGB(props.TextColour.R, props.TextColour.G, props.TextColour.B);
        }
    }
}