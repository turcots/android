using Android.App;
using Android.OS;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "ToptoBottomActivity")]
    public class ToptoBottomActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Toptobottom);
        }
    }
}