using Android.OS;
using Android.Views;
using Android.Widget;
using FormsEmbedding.ViewModel;

namespace FormsEmbedding.Droid
{
    public class AboutFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        public static AboutFragment NewInstance() =>
            new AboutFragment { Arguments = new Bundle() };

        public AboutViewModel ViewModel { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        Button learnMoreButton;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_about, container, false);
            ViewModel = new AboutViewModel();
            learnMoreButton = view.FindViewById<Button>(Resource.Id.button_learn_more);
            return view;
        }

        public override void OnStart()
        {
            base.OnStart();
            learnMoreButton.Click += LearnMoreButton_Click;
        }

        private void LearnMoreButton_Click(object sender, System.EventArgs e)
        {
            ViewModel.OpenWebCommand.Execute(null);
        }

        public override void OnStop()
        {
            base.OnStop();
            learnMoreButton.Click -= LearnMoreButton_Click;
        }

        public void BecameVisible()
        {

        }
    }
}