namespace AdaptTablet.Views
{
    using System.Threading.Tasks;
    using ViewModels;
    using Xamarin.Forms;

    public partial class DriverDetailView : ContentPage
    {
        private bool _animate;

        private object Parameter { get; set; }

        public DriverDetailView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;
            BindingContext = App.Locator.DriverDetailViewModel;
        }

        protected override async void OnAppearing()
        {
            var viewModel = BindingContext as DriverDetailViewModel;
            if (viewModel != null) viewModel.OnAppearing(Parameter);

            var content = this.Content;
            this.Content = null;
            this.Content = content;

            _animate = true;

            await AnimateIn();
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as DriverDetailViewModel;
            if (viewModel != null) viewModel.OnDisappearing();

            _animate = false;
        }

        public async Task AnimateIn()
        {
            await AnimateItem(img, 10500);
        }

        private async Task AnimateItem(View uiElement, uint duration)
        {
            while (_animate)
            {
                await uiElement.ScaleTo(1.05, duration, Easing.SinInOut);

                await Task.WhenAll(
                    uiElement.FadeTo(1, duration, Easing.SinInOut),
                    uiElement.LayoutTo(new Rectangle(new Point(0, 0), new Size(uiElement.Width, uiElement.Height))),
                    uiElement.FadeTo(.9, duration, Easing.SinInOut),
                    uiElement.ScaleTo(1.25, duration, Easing.SinInOut)
                );
            }
        }
    }
}
