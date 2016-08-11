using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using Android.Support.V7.App;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "DetectGSMSignalStrength")]
    class DetectGSMSignalStrength : AppCompatActivity
    {
        TelephonyManager _telephonyManager;
        GsmSignalStrengthListener _signalStrengthListener;
        TextView _gmsStrengthTextView;
        ImageView _gmsStrengthImageView;
        Button _getGsmSignalStrengthButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.DetectGSMSignalStrength);

            // Get a reference to the TelephonyManager and instantiate the GsmSignalStrengthListener.
            // These will be used by the Button's OnClick event handler.
            _telephonyManager = (TelephonyManager)GetSystemService(Context.TelephonyService);
            _signalStrengthListener = new GsmSignalStrengthListener();

            _gmsStrengthTextView = FindViewById<TextView>(Resource.Id.textView1);
            _gmsStrengthImageView = FindViewById<ImageView>(Resource.Id.imageView1);
            _getGsmSignalStrengthButton = FindViewById<Button>(Resource.Id.myButton);

            _getGsmSignalStrengthButton.Click += DisplaySignalStrength;
        }

        void HandleSignalStrengthChanged(int strength)
        {
            // We want this to be a one-shot thing when the button is pushed. Make sure to unhook everything
            _signalStrengthListener.SignalStrengthChanged -= HandleSignalStrengthChanged;
            _telephonyManager.Listen(_signalStrengthListener, PhoneStateListenerFlags.None);

            // Update the UI with text and an image.
            _gmsStrengthImageView.SetImageLevel(strength);
            _gmsStrengthTextView.Text = string.Format("GPS Signal Strength ({0}):", strength);
        }
        void DisplaySignalStrength(object sender, EventArgs e)
        {
            _telephonyManager.Listen(_signalStrengthListener, PhoneStateListenerFlags.SignalStrengths);
            _signalStrengthListener.SignalStrengthChanged += HandleSignalStrengthChanged;
        }
    }

    public class GsmSignalStrengthListener : PhoneStateListener
    {
        public delegate void SignalStrengthChangedDelegate(int strength);

        public event SignalStrengthChangedDelegate SignalStrengthChanged;

        public override void OnSignalStrengthsChanged(SignalStrength newSignalStrength)
        {
            if (newSignalStrength.IsGsm)
            {
                if (SignalStrengthChanged != null)
                {
                    SignalStrengthChanged(newSignalStrength.GsmSignalStrength);
                }
            }
        }
    }
}
