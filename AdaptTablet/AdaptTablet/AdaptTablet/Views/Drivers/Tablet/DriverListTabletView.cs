using Xamarin.Forms;

namespace AdaptTablet.Views.Drivers.Tablet
{
    public class DriverListTabletView : MasterDetailPage
    {
        private object Parameter { get; set; }

        public DriverListTabletView(object parameter)
        {
            Title = "Drivers";

            Parameter = parameter;
		
            Master = new DriverListView(null);

            Detail = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label
                        {
                            Text = "Select a Driver",
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                        }
                    }
                }
            };
				
			((DriverListView)Master).ItemSelected = (driver) =>
			{
				Detail = new DriverDetailView(driver);
				if (Device.OS != TargetPlatform.Windows)
					IsPresented = false;
			};

            IsPresented = true;
        }

        protected override bool OnBackButtonPressed()
        {
            if (IsPresented)
            {
                return base.OnBackButtonPressed();
            }
            else
            {
                IsPresented = true;
                return true;
            }
        }
    }
}
