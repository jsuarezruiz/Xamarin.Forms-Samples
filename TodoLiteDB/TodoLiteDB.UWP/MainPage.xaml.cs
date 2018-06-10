namespace TodoLiteDB.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TodoLiteDB.App());
        }
    }
}
