using System.Threading.Tasks;
using System.Windows.Input;

namespace FormulaOneApp.Controls.HubTileAbstraction
{
    using Xamarin.Forms;

    public class CustomHubTileView : View
    {
        public CustomHubTileView()
        {
            Initialize();
        }

        public void Initialize()
        {
            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = TappedCommand
            });
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create<CustomHubTileView, string>(p => p.Title, string.Empty);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty MessageProperty = BindableProperty.Create<CustomHubTileView, string>(p => p.Message, string.Empty);

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly BindableProperty SourceProperty = BindableProperty.Create<CustomHubTileView, ImageSource>(p => p.Source, string.Empty);

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly BindableProperty ColorProperty = BindableProperty.Create<CustomHubTileView, Color>(p => p.Color, Color.Default);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create<CustomHubTileView, ICommand>(p => p.Command, null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private ICommand TappedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Task.Delay(100);
                    if (Command != null)
                    {
                        Command.Execute(null);
                    }
                });
            }
        }
    }
}