using System;
using Xamarin.Forms;

namespace Redux.Views
{
    public static class EntryEvents
    {
        public static readonly BindableProperty TextChangeActionProperty = EventWrapperFactory.Create
            <Entry, Action<string>, EventHandler<TextChangedEventArgs>>(
                propertyName: "TextChangeAction",
                unwrap: fn => (sender, args) => fn(args.NewTextValue),
                addHandler: (view, handler) => view.TextChanged += handler,
                removeHandler: (view, handler) => view.TextChanged -= handler);

        public static Action<string> GetTextChangeAction(Entry view)
        {
            return (Action<string>)view.GetValue(TextChangeActionProperty);
        }

        public static void SetTextChangeAction(Entry view, Action<string> value)
        {
            view.SetValue(TextChangeActionProperty, value);
        }
    }
}
