namespace Calculator.Views
{
    using Xamarin.Forms;

    public partial class CalculatorView
    {
        public CalculatorView()
        {
            InitializeComponent();

            BindingContext = App.Locator.CalculatorViewModel;
        }
    }
}
