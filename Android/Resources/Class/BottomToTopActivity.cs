using Android.App;
using Android.OS;

namespace Android
{
    [Activity(Label = "BottomToTopActivity")]
    public class BottomToTopActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.bottomtotop);
        }
    }
}