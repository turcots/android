using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Resources.Class;

namespace Android
{
    [Activity(Label = "Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        public Button BtnSlider
        {
            get { return FindViewById<Button>(Resource.Id.BtnSlider); }
        }
        public Button BtnPopup
        {
            get { return FindViewById<Button>(Resource.Id.BtnPopup); }
        }
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            BtnSlider.Click += BtnSlider_Click;
            BtnPopup.Click += BtnPopup_Click;
        }

        private void BtnPopup_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(Popup));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }

        private void BtnSlider_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(Slider));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }
    }
}

