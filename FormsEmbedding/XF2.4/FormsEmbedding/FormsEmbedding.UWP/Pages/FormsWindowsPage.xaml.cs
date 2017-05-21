using FormsEmbedding.Forms;
using System;
using Windows.UI.Xaml.Navigation;

namespace FormsEmbedding.UWP.Pages
{
    public sealed partial class FormsWindowsPage 
    {
        private readonly XamarinFormsApp _formsApp;

        public FormsWindowsPage()
        {
            this.InitializeComponent();

            _formsApp = new XamarinFormsApp();
            LoadApplication(_formsApp);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _formsApp.SetPage(e.Parameter as Type);
        }
    }
}
