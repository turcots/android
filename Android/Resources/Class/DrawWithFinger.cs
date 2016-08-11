
using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "DrawWithFinger")]
    class DrawWithFinger : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            DrawView test = new DrawView(this);
            test.start();

            SetContentView(test);
        }
    }
}