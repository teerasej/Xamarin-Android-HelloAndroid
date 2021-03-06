using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace HelloAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            EditText textName = FindViewById<EditText>(Resource.Id.inputName);
            TextView textResult = FindViewById<TextView>(Resource.Id.txtResult);
            Button buttonHello = FindViewById<Button>(Resource.Id.buttonHello);

            buttonHello.Click += (sender, e) =>
            {
                if(textName.Text == string.Empty)
                {
                    var toast = Toast.MakeText(Application.Context, "กรอกชื่อก่อน", ToastLength.Short);
                    toast.Show();
                    return;
                }

                textResult.Text = "Hello, " + textName.Text;
                textName.Text = "";
            };
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            base.OnResume();

            Console.WriteLine("Resume from dead...");
        }

        protected override void OnPause()
        {
            base.OnPause();

            Console.WriteLine("Freezing....");
        }
    }
}