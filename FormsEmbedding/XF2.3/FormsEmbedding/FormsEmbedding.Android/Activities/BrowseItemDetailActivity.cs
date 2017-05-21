
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using FormsEmbedding.Model;
using FormsEmbedding.ViewModel;

namespace FormsEmbedding.Droid
{
    [Activity(Label = "Details", ParentActivity = typeof(MainActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = ".MainActivity")]
    public class BrowseItemDetailActivity : BaseActivity
    {
        /// <summary>
        /// Specify the layout to inflace
        /// </summary>
        protected override int LayoutResource => Resource.Layout.activity_item_details;


        ItemDetailViewModel viewModel;
        Spinner spinner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var data = Intent.GetStringExtra("data");

            var item = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(data);
            viewModel = new ItemDetailViewModel(item);

            FindViewById<TextView>(Resource.Id.description).Text = item.Description;


            SupportActionBar.Title = item.Text;
        }


        protected override void OnStart()
        {
            base.OnStart();
            viewModel.PropertyChanged += ViewModel_PropertyChanged;

        }


        protected override void OnStop()
        {
            base.OnStop();
            viewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }


        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}