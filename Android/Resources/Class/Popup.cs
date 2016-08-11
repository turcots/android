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
using Android.Support.V7.App;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "Popup")]
    class Popup : AppCompatActivity
    {
        Button BtnAlertDialog;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Popup);

            InitRessources();
            InitEvents();

        }
        private void InitRessources()
        {
            BtnAlertDialog = FindViewById<Button>(Resource.Id.BtnAlertDialog);
        }

        private void InitEvents()
        {
            BtnAlertDialog.Click += BtnAlertDialog_Click;
        }

        private void BtnAlertDialog_Click(object sender, EventArgs e)
        {
            var alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetView(LayoutInflater.Inflate(Resource.Layout.PopupXml, null));
            alert.Create().Show();
        }
    }
}