namespace TodoSqlite.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TodoSqlite.App());
        }
    }
}
