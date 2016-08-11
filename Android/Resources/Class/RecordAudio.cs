using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Support.V7.App;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "RecordAudio")]
    class RecordAudio : AppCompatActivity
    {
        MediaRecorder _recorder;
        MediaPlayer _player;
        Button _start;
        Button _stop;

        string path = "/sdcard/test.3gpp";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RecordAudio);

            _start = FindViewById<Button>(Resource.Id.start);
            _stop = FindViewById<Button>(Resource.Id.stop);

            _start.Click += _start_Click;
            _stop.Click += _stop_Click;
        }

        private void _start_Click(object sender, EventArgs e)
        {
            _stop.Enabled = !_stop.Enabled;
            _start.Enabled = !_start.Enabled;

            _recorder.SetAudioSource(AudioSource.Mic);
            _recorder.SetOutputFormat(OutputFormat.ThreeGpp);
            _recorder.SetAudioEncoder(AudioEncoder.AmrNb);
            _recorder.SetOutputFile(path);
            _recorder.Prepare();
            _recorder.Start();
        }

        private void _stop_Click(object sender, EventArgs e)
        {
            _stop.Enabled = !_stop.Enabled;

            _recorder.Stop();
            _recorder.Reset();

            _player.SetDataSource(path);
            _player.Prepare();
            _player.Start();
        }

        protected override void OnResume()
        {
            base.OnResume();

            _recorder = new MediaRecorder();
            _player = new MediaPlayer();

            _player.Completion += (sender, e) =>
            {
                _player.Reset();
                _start.Enabled = !_start.Enabled;
            };

        }

        protected override void OnPause()
        {
            base.OnPause();

            _player.Release();
            _recorder.Release();
            _player.Dispose();
            _recorder.Dispose();
            _player = null;
            _recorder = null;
        }
    }
}