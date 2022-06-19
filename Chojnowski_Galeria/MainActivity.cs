using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Timers;

namespace Chojnowski_Galeria
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int counter = 0;
        int[] imgTab = new int[3];
        Button next;
        Button back;
        ImageView image;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            back = FindViewById<Button>(Resource.Id.button1);
            next = FindViewById<Button>(Resource.Id.button2);
            image = FindViewById<ImageView>(Resource.Id.imageView1);

            int[] imgTab = new int[3];

            imgTab[0] = Resource.Drawable.img1;
            imgTab[1] = Resource.Drawable.img2;
            imgTab[2] = Resource.Drawable.img3;

            next.Click += delegate
            {
                if (counter < imgTab.Length - 1) counter++; else counter = 0;
                image.SetImageResource(imgTab[counter]);
            };
            back.Click += delegate
            {
                if (counter > 0) counter--; else counter = imgTab.Length - 1;
                image.SetImageResource(imgTab[counter]);
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}