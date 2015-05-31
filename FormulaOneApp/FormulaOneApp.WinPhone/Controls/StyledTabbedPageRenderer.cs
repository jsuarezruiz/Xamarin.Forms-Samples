using FormulaOneApp.Controls.StyledTabbedPageAbstraction;
using FormulaOneApp.WinPhone.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using Application = System.Windows.Application;
using Style = System.Windows.Style;

[assembly: ExportRenderer(typeof(StyledTabbedPage), typeof(StyledTabbedPageRenderer))]
namespace FormulaOneApp.WinPhone.Controls
{
    public class StyledTabbedPageRenderer : TabbedPageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            this.Style = Application.Current.Resources["PivotStyle"] as Style;
        }
    }
}
