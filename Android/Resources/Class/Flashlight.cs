using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Hardware.Camera2;
using Android.Support.V7.App;

namespace Android.Resources.Class
{
    [Activity(Label = "Flashlight")]

        public class Flashlight : AppCompatActivity
        {
            //Android.Hardware.Camera2. cam;

            Camera camera;
            bool cameraFlashLightOn;

            public Button BtnOn
            {
                get { return FindViewById<Button>(Resource.Id.BtnOn); }
            }

            public Button BtnOff
            {
                get { return FindViewById<Button>(Resource.Id.BtnOff); }
            }

            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Flashlight);

                BtnOn.Click += BtnOn_Click;
                BtnOff.Click += BtnOff_Click;
            }

            private void BtnOff_Click(object sender, EventArgs e)
            {
                var parameters = camera.GetParameters();

                parameters.FlashMode = Camera.Parameters.FlashModeOff;

                camera.SetParameters(parameters);
                camera.StopPreview();
                cameraFlashLightOn = false;
            }

            private void BtnOn_Click(object sender, EventArgs e)
            {
                var parameters = camera.GetParameters();

                if (!cameraFlashLightOn)
                {
                    parameters.FlashMode = Camera.Parameters.FlashModeTorch;

                    camera.SetParameters(parameters);
                    camera.StartPreview();
                    cameraFlashLightOn = true;
                    return;
                }
            }

            protected override void OnResume()
            {
                if (!PackageManager.HasSystemFeature(Android.Content.PM.PackageManager.FeatureCamera))
                {
                    Toast.MakeText(this, "No back-facing camera available", ToastLength.Long);
                    return;
                }

                if (!PackageManager.HasSystemFeature(Android.Content.PM.PackageManager.FeatureCameraFlash))
                {
                    Toast.MakeText(this, "No camera flash available", ToastLength.Long);
                    return;
                }

                camera = Camera.Open();

                base.OnResume();
            }

            protected override void OnStop()
            {
                camera.Release();

                base.OnStop();
            }

        
    }
}