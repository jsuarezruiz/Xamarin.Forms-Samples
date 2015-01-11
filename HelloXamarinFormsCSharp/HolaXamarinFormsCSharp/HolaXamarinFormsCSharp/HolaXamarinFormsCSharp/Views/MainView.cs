using HolaXamarinFormsCSharp.ViewModels;
using Xamarin.Forms;

namespace HolaXamarinFormsCSharp.Views
{
    public class MainView : ContentPage
    {
        public MainView()
        {
            // DataContext de la página, nuestro ViewModel
            BindingContext = new MainViewModel();

            //Contenedor principal
            var stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(0, 10)
            };

            //Texto informativo
            var info = new Label
            {
                Font = Font.SystemFontOfSize(NamedSize.Medium),
                Text = "Hola Xamarin Forms!",
                LineBreakMode = LineBreakMode.WordWrap
            };

            //Añadimos el texto a nuestro contenedor
            stack.Children.Add(info);

            //Añadimos un botón. Al pulsarlo, actualizará el número de veces que lo pulsamos
            var button = new Button
            {
                Text = "Púlsame!",
                Command = ViewModel.HelloCommand
            };

            //Añadimos el botón a nuestro contenedor
            stack.Children.Add(button);

            var result = new Label
            {
                Font = Font.SystemFontOfSize(NamedSize.Large)
            };

            result.SetBinding(Label.TextProperty, "Message");

            //Añadimos el texto a nuestro contenedor
            stack.Children.Add(result);

            // Añadimos nuestro contenedor como contenido
            Content = stack;
        }

        private MainViewModel ViewModel
        {
            get { return BindingContext as MainViewModel; }
        }
    }
}
