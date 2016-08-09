
using Android.App;
using Android.OS;

namespace Android
{
    [Activity(Label = "bottomtotop")]
    public class bottomtotop : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.bottomtotop);
        }
    }
}