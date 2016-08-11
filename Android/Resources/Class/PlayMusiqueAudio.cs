using System;
using Android.App;
using Android.OS;
using Android.Widget;

using Android.Support.V7.App;
using Android.Media;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "PlayMusiqueAudio")]
    class PlayMusiqueAudio : AppCompatActivity
    {
        Button BtnPlay;
        Button BtnStop;

        MediaPlayer _player;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.PlayMusiqueAudio);

            BtnPlay = FindViewById<Button>(Resource.Id.BtnPlay);
            BtnStop = FindViewById<Button>(Resource.Id.BtnStop);

            BtnPlay.Click += BtnPlay_Click;
            BtnStop.Click += BtnStop_Click;
        }


        private void BtnPlay_Click(object sender, EventArgs e)
        {
            _player = MediaPlayer.Create(this, Resource.Raw.SleepAway);
            _player.Start();

        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _player.Stop();

        }
    }
}