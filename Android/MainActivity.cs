﻿using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using AndroidApp.Resources.Class;
using Android;

namespace AndroidApp
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

        public Button BtnFlashlight
        {
            get { return FindViewById<Button>(Resource.Id.BtnFlashlight); }
        }

        public Button BtnSQlite
        {
            get { return FindViewById<Button>(Resource.Id.BtnSQlite); }
        }

        public Button BtnDrawWithFinger
        {
            get { return FindViewById<Button>(Resource.Id.BtnDrawWithFinger); }
        }

        public Button BtnGesture
        {
            get { return FindViewById<Button>(Resource.Id.BtnGesture); }
        }

        public Button BtnPlayMusiqueAudio
        {
            get { return FindViewById<Button>(Resource.Id.BtnPlayMusiqueAudio); }
        }

        public Button BtnRecordAudio
        {
            get { return FindViewById<Button>(Resource.Id.BtnRecordAudio); }
        }

        public Button BtnRecordVideo
        {
            get { return FindViewById<Button>(Resource.Id.BtnRecordVideo); }
        }
        public Button BtnDetectGSMSignalStrength
        {
            get { return FindViewById<Button>(Resource.Id.BtnDetectGSMSignalStrength); }
        }

        public Button BtnCardFlip
        {
            get { return FindViewById<Button>(Resource.Id.BtnCardFlip); }
        }
        public Button BtnActionBarDrawer
        {
            get { return FindViewById<Button>(Resource.Id.BtnActionBarDrawer); }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            InitEvents();
        }

        private void InitEvents()
        {
            BtnSlider.Click += BtnSlider_Click;
            BtnPopup.Click += BtnPopup_Click;
            BtnFlashlight.Click += BtnFlashlight_Click;
            BtnSQlite.Click += BtnSQlite_Click;
            BtnDrawWithFinger.Click += BtnDrawWithFinger_Click;
            BtnGesture.Click += BtnGesture_Click;
            BtnPlayMusiqueAudio.Click += BtnPlayMusiqueAudio_Click;
            BtnRecordAudio.Click += BtnRecordAudio_Click;
            BtnRecordVideo.Click += BtnRecordVideo_Click;
            BtnDetectGSMSignalStrength.Click += BtnDetectGSMSignalStrength_Click;
            BtnCardFlip.Click += BtnCardFlip_Click;
            BtnActionBarDrawer.Click += BtnActionBarDrawer_Click;
        }

        private void BtnActionBarDrawer_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(ActionBarDrawer));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }

        private void BtnCardFlip_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(CardFlip));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }

        private void BtnDetectGSMSignalStrength_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(DetectGSMSignalStrength));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }

        private void BtnRecordVideo_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(RecordVideo));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);

        }

        private void BtnRecordAudio_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(RecordAudio));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }

        private void BtnPlayMusiqueAudio_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(PlayMusiqueAudio));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }

        private void BtnGesture_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(Gesture));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }

        private void BtnDrawWithFinger_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(DrawWithFinger));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }

        private void BtnSQlite_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(SQliteUser));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }

        private void BtnFlashlight_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(Flashlight));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
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

