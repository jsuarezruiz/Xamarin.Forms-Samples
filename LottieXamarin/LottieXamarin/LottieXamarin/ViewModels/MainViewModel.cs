using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace LottieXamarin.ViewModels
{
    public class MainViewModel : BindableObject
    {
        public ICommand PlayingCommand => new Command(Playing);

        public ICommand FinishedCommand => new Command(Finished);

        public ICommand PlayCommand => new Command(Play);

        public ICommand PauseCommand => new Command(Pause);

        private void Playing()
        {
            Debug.WriteLine("PlayingCommand executed!");
        } 

        private void Finished()
        {
            Debug.WriteLine("FinishedCommand executed!");
        }

        private void Play()
        {
            MessagingCenter.Send(this, AppSettings.PlayMessage);
        }

        private void Pause()
        {
            MessagingCenter.Send(this, AppSettings.PauseMessage);
        }
    }
}