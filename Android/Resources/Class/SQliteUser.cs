using System;
using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;
using AndroidApp.Resources.Class;
using Android.Support.V7.App;

namespace AndroidApp.Resources.Class
{
    [Activity(Label = "SQliteUser")]
    class SQliteUser : AppCompatActivity
    {
        Database<Person> dbPerson;

        public TextView TxtNom
        {
            get { return FindViewById<TextView>(Resource.Id.txtNom); }
        }
        public TextView TxtPrenom
        {
            get { return FindViewById<TextView>(Resource.Id.txtPrenom); }
        }

        public TextView LblCount
        {
            get { return FindViewById<TextView>(Resource.Id.lblCount); }
        }

        public ListView LvPerson
        {
            get { return FindViewById<ListView>(Resource.Id.lvPerson); }
        }
        public TextView IdentifiantPerson
        {
            get { return FindViewById<TextView>(Resource.Id.identifiantPerson); }
        }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.SQliteUser);

            dbPerson = new Database<Person>("person.db");

            Button btnAjouter = FindViewById<Button>(Resource.Id.btnAjouter);
            Button btnModifier = FindViewById<Button>(Resource.Id.btnModifier);
            Button btnSupprimer = FindViewById<Button>(Resource.Id.btnSupprimer);

            btnAjouter.Click += BtnAjouter_Click;
            btnModifier.Click += BtnModifier_Click;
            btnSupprimer.Click += BtnSupprimer_Click;

            AfficherCount();
            ListePersonne();

            LvPerson.ItemClick += LvPerson_ItemClick;
        }

        private void LvPerson_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            ListView obj = ((ListView)sender);

            //obj.Selected;
            //obj.SelectedItemId;
            //obj.SelectedView;

            var test = ((ListView)sender).SelectedItem;
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            dbPerson.Supprimer(int.Parse(IdentifiantPerson.Text));
            AfficherCount();
            ListePersonne();
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            var person = new Person { ID = int.Parse(IdentifiantPerson.Text), FirstName = TxtPrenom.Text, LastName = TxtNom.Text };
            dbPerson.Modifier(person);
            InitialiserChamps();
            AfficherCount();
            ListePersonne();
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            // Insert person into the database
            var person = new Person { FirstName = TxtPrenom.Text, LastName = TxtNom.Text };
            dbPerson.Inserer(person);
            InitialiserChamps();
            AfficherCount();
            ListePersonne();
        }

        private void InitialiserChamps()
        {
            IdentifiantPerson.Text = string.Empty;
            TxtNom.Text = string.Empty;
            TxtPrenom.Text = string.Empty;
        }

        private void AfficherCount()
        {
            LblCount.Text = "Nombre de personnes : " + dbPerson.Recuperer().Count().ToString();
        }

        private void ListePersonne()
        {
            LvPerson.Adapter = new ArrayAdapter<Person>(this, Android.Resource.Layout.SimpleSelectableListItem, dbPerson.Recuperer());
        }

    }


}

