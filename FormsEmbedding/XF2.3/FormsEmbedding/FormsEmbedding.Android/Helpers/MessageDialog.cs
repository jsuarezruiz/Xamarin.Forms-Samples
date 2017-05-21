using System;
using Android.App;
using Android.Widget;
using FormsEmbedding.Interfaces;
using Plugin.CurrentActivity;

namespace FormsEmbedding.Droid
{
    public class MessageDialog : IMessageDialog
    {
        public void SendMessage(string message, string title = null)
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var builder = new AlertDialog.Builder(activity);
            builder
                .SetTitle(title ?? string.Empty)
                .SetMessage(message)
                .SetPositiveButton(Android.Resource.String.Ok, delegate
                {

                });

            activity.RunOnUiThread(() =>
            {
                AlertDialog alert = builder.Create();
                alert.Show();
            });
        }


        public void SendToast(string message)
        {
            var activity = CrossCurrentActivity.Current.Activity;
            activity.RunOnUiThread(() =>
            {
                Toast.MakeText(activity, message, ToastLength.Long).Show();
            });

        }


        public void SendConfirmation(string message, string title, Action<bool> confirmationAction)
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var builder = new AlertDialog.Builder(activity);
            builder
            .SetTitle(title ?? string.Empty)
            .SetMessage(message)
            .SetPositiveButton(Android.Resource.String.Ok, delegate
            {
                confirmationAction(true);
            }).SetNegativeButton(Android.Resource.String.Cancel, delegate
            {
                confirmationAction(false);
            });

            activity.RunOnUiThread(() =>
            {
                AlertDialog alert = builder.Create();
                alert.Show();
            });
        }

    }
}