
using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "Gesture")]
    class Gesture : AppCompatActivity, GestureDetector.IOnGestureListener, View.IOnTouchListener
    {
        private GestureDetector _gestureDetector;
        private Button _myButton;
        private float _viewX;
        private float _viewY;

        public TextView TextView1
        {
            get { return FindViewById<TextView>(Resource.Id._textView); }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Gesture);

            TextView1.Text = "Fling Velocity: ";
            _gestureDetector = new GestureDetector(this);

            _myButton = FindViewById<Button>(Resource.Id.myView);
            _myButton.SetOnTouchListener(this);
        }

        public bool OnDown(MotionEvent e)
        {
            return false;
        }

        public void OnLongPress(MotionEvent e) { }
        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            return false;
        }
        public void OnShowPress(MotionEvent e) { }
        public bool OnSingleTapUp(MotionEvent e)
        {
            return false;
        }
        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            TextView1.Text = String.Format("Fling velocity: {0} x {1}", velocityX, velocityY);
            return true;
        }
        public override bool OnTouchEvent(MotionEvent e)
        {
            _gestureDetector.OnTouchEvent(e);
            return false;
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Up:
                    _viewY = e.GetY();
                    break;
                case MotionEventActions.Down:
                    _viewX = e.GetX();
                    break;
                case MotionEventActions.Move:
                    var left = (int)(e.RawX - _viewX);
                    var right = (int)(left + v.Width);
                    var top = (int)(v.Top);
                    var bottom = (int)(v.Bottom);

                    v.Layout(left, top, right, bottom);
                    break;
            }
            return true;
        }
    }
}

