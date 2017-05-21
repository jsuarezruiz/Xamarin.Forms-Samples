using System;
using FormsEmbedding.Interfaces;
using MessageBox = Windows.UI.Popups.MessageDialog;
using Windows.UI.Popups;

namespace FormsEmbedding.UWP.Helpers
{
    public class MessageDialog : IMessageDialog
    {

        public async void SendMessage(string message, string title = null)
        {
            var dialog = new MessageBox(message, title ?? string.Empty);
            await dialog.ShowAsync();
        }


        public void SendToast(string message)
        {
            SendMessage(message);
        }

        public async void SendConfirmation(string message, string title, Action<bool> confirmationAction)
        {
            var dialog = new MessageBox(message, title ?? string.Empty);
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            confirmationAction?.Invoke((int)res.Id == 0);
        }
    }
}
