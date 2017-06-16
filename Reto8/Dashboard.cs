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

namespace reto8
{
    [Activity(Label = "Recuerdalo", Icon = "@drawable/ic_launcher", Theme = "@style/Theme.AppCompat.Light")]
    public class Dashboard : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Dashboard);

            var btnImportante = FindViewById<Button>(Resource.Id.buttonEvento);

            btnImportante.Click += (sender, e) =>
            {
                AbrirDialog();
            };
        }

        private void AbrirDialog()
        {
            LayoutInflater layoutInflaterAndroid = LayoutInflater.From(this);
            View nView = layoutInflaterAndroid.Inflate(Resource.Layout.dialog_Formulario, null);
            Android.Support.V7.App.AlertDialog.Builder alertDialogBuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
            alertDialogBuilder.SetView(nView);
            var userContent = nView.FindViewById<EditText>(Resource.Id.nombre);
            alertDialogBuilder.SetCancelable(false)
            .SetPositiveButton("Send", delegate
             {
                 Toast.MakeText(this, "Send content: " + userContent.Text, ToastLength.Short).Show();
             })
            .SetNegativeButton("Cancel", delegate
            {
                alertDialogBuilder.Dispose();
            });
            Android.Support.V7.App.AlertDialog alertDialogAndroid = alertDialogBuilder.Create();
            alertDialogAndroid.Show();
        }
    }
}