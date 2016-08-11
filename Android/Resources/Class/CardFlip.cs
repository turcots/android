using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "CardFlip")]
    class CardFlip : AppCompatActivity
    {
        public GestureDetector mGestureDetector;
        private bool mShowingBack;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.CardFlip);

            mGestureDetector = new GestureDetector(this, new MyGestureListener(this));

            if (bundle == null)
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                transaction.Add(Resource.Id.container, new CardFrontFragment());
                transaction.Commit();

            }
        }

        public void FlipCard()
        {
            if (mShowingBack)
            {
                //Pop back to the last fragment
                FragmentManager.PopBackStack();
                mShowingBack = false;
            }
            else
            {
                //otherwise the front is showing
                FragmentTransaction transaction = FragmentManager.BeginTransaction();

                //set the custom animations we made to animate with this transaction
                transaction.SetCustomAnimations(Resource.Animation.card_flip_right_in, Resource.Animation.card_flip_right_out,
                    Resource.Animation.card_flip_left_in, Resource.Animation.card_flip_left_out);

                transaction.Replace(Resource.Id.container, new CardBackFragment());

                transaction.AddToBackStack(null);
                transaction.Commit();

                mShowingBack = true;
            }

        }

        public class CardFrontFragment : Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                View frontCard = inflater.Inflate(Resource.Layout.card_front, container, false);
                frontCard.Click += FrontCard_Click;
                frontCard.Touch += FrontCard_Touch;
                return frontCard;
            }

            private void FrontCard_Touch(object sender, View.TouchEventArgs e)
            {
                CardFlip parentActivity = Activity as CardFlip;
                parentActivity.mGestureDetector.OnTouchEvent(e.Event);
            }

            private void FrontCard_Click(object sender, EventArgs e)
            {

            }
        }

        public class CardBackFragment : Fragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                View backCard = inflater.Inflate(Resource.Layout.card_back, container, false);
                backCard.Click += BackCard_Click;
                backCard.Touch += BackCard_Touch;
                return backCard;
            }

            private void BackCard_Touch(object sender, View.TouchEventArgs e)
            {
                CardFlip parentActivity = Activity as CardFlip;
                parentActivity.mGestureDetector.OnTouchEvent(e.Event);
            }

            private void BackCard_Click(object sender, EventArgs e)
            {

            }
        }

        public class MyGestureListener : GestureDetector.SimpleOnGestureListener
        {
            private CardFlip mMainActivity;

            public MyGestureListener(CardFlip activity)
            {
                mMainActivity = activity;
            }
            public override bool OnDoubleTap(MotionEvent e)
            {
                Console.WriteLine("OnDoubleTap");
                mMainActivity.FlipCard();

                return true;
            }

            public override void OnLongPress(MotionEvent e)
            {
                Console.WriteLine("OnLongPress");
            }

            public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
            {
                Console.WriteLine("OnFling");
                return base.OnFling(e1, e2, velocityX, velocityY);
            }

            public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
            {
                Console.WriteLine("OnScroll");
                return base.OnScroll(e1, e2, distanceX, distanceY);
            }
        }
    }

}
