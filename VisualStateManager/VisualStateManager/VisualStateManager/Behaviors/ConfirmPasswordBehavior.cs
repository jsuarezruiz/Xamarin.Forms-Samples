using Xamarin.Forms;

namespace VisualStateManager.Behaviors
{
	public class ConfirmPasswordBehavior : Behavior<Entry>
	{
		public static readonly BindableProperty CompareToEntryProperty =
			BindableProperty.Create("CompareToEntry", typeof(Entry), typeof(ConfirmPasswordBehavior), null);

		public Entry CompareToEntry
		{
			get { return (Entry)GetValue (CompareToEntryProperty); }
			set { SetValue (CompareToEntryProperty, value); }
		}

		protected override void OnAttachedTo (Entry bindable)
		{
			bindable.TextChanged += HandleTextChanged;
			base.OnAttachedTo (bindable);
		}
		protected override void OnDetachingFrom (Entry bindable)
		{
			bindable.TextChanged -= HandleTextChanged;
			base.OnDetachingFrom (bindable);
		}

		void HandleTextChanged (object sender, TextChangedEventArgs e)
		{
			var password = CompareToEntry.Text;

			if (string.IsNullOrEmpty (password))
				return;

			var confirmPassword = e.NewTextValue;
			var isValid = password.Equals (confirmPassword);

			if (isValid) 
			{
				Xamarin.Forms.VisualStateManager.GoToState ((Entry)sender, "Valid");
			} 
			else 
			{
				Xamarin.Forms.VisualStateManager.GoToState ((Entry)sender, "Invalid");
			}
		}
	}
}