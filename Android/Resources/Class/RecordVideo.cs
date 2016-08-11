using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Support.V7.App;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "RecordAudio")]
    class RecordVideo : AppCompatActivity
    {
        MediaRecorder recorder;
        string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/test.mp4";

        Button record;
        Button stop;
        Button play;
        VideoView video;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RecordVideo);

            record = FindViewById<Button>(Resource.Id.Record);
            stop = FindViewById<Button>(Resource.Id.Stop);
            play = FindViewById<Button>(Resource.Id.Play);
            video = FindViewById<VideoView>(Resource.Id.SampleVideoView);


            record.Click += Record_Click;
            stop.Click += Stop_Click;
            play.Click += Play_Click;
        }


        private void Play_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse(path);
            video.SetVideoURI(uri);
            video.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (recorder != null)
            {
                recorder.Stop();
                recorder.Release();
            }

        }
        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (recorder != null)
            {
                recorder.Release();
                recorder.Dispose();
                recorder = null;
            }
        }

        private void Record_Click(object sender, EventArgs e)
        {
            video.StopPlayback();

            recorder = new MediaRecorder();
            recorder.SetVideoSource(VideoSource.Camera);
            recorder.SetAudioSource(AudioSource.Mic);
            recorder.SetOutputFormat(OutputFormat.Default);
            recorder.SetVideoEncoder(VideoEncoder.Default);
            recorder.SetAudioEncoder(AudioEncoder.Default);
            recorder.SetOutputFile(path);
            recorder.SetPreviewDisplay(video.Holder.Surface);
            recorder.Prepare();
            recorder.Start();
        }
    }
}

