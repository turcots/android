using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "Slider")]
    class Slider : Activity
    {
        Button Righttoleft;
        Button bottomtotop;
        Button lefttoright;
        Button toptobottom;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Slider);

            Righttoleft = FindViewById<Button>(Resource.Id.righttoleft);
            bottomtotop = FindViewById<Button>(Resource.Id.bottomtotop);
            lefttoright = FindViewById<Button>(Resource.Id.lefttoright);
            toptobottom = FindViewById<Button>(Resource.Id.toptobottom);
            Righttoleft.Click += Righttoleft_Click;
            bottomtotop.Click += bottomtotop_Click;
            lefttoright.Click += Lefttoright_Click;
            toptobottom.Click += Toptobottom_Click;
        }

        private void Toptobottom_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(ToptoBottomActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Pushdown_in, Resource.Animation.@Pushdown_out);
        }
        private void Lefttoright_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(LeftToRightActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_left, Resource.Animation.@Side_out_right);
        }
        private void bottomtotop_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(BottomToTopActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Pushup_in, Resource.Animation.@Pushup_out);
        }
        private void Righttoleft_Click(object sender, EventArgs e)
        {
            Intent intent;
            intent = new Intent(this, typeof(RighttoLeftActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.@Side_in_right, Resource.Animation.@Side_out_left);
        }
    }
}