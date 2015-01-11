using System;
using Xamarin.Forms;

namespace Entry_Behavior.Behaviors
{
    public class NumericEntryBehavior : Behavior<Entry>
    {
        private string _lastValidText;

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += EntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= EntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void EntryTextChanged(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            if (entry != null)
            {
                double value;
                if (string.IsNullOrEmpty(entry.Text) ||
                    Double.TryParse(entry.Text, out value))
                {
                    _lastValidText = entry.Text;
                    return;
                }

                entry.Text = _lastValidText;
            }
        }
    }
}
