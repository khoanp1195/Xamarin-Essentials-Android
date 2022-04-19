using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace XamarinEssetial
{
    [Activity(Label = "flashlight")]
    public class flashlight : Activity
    {

        Button btnOn, btnOff;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.flashlight);

            // Create your application here


            btnOn = FindViewById<Button>(Resource.Id.btnON);
            btnOn.Click += BtnOn_Click;


            btnOff = FindViewById<Button>(Resource.Id.btnOff);
            btnOff.Click += BtnOff_Click;
           
        }

        private async void BtnOff_Click(object sender, EventArgs e)
        {
            try
            {
              
                // Turn Off
                await Flashlight.TurnOffAsync();
            }

            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
            }
        }

        private async void BtnOn_Click(object sender, EventArgs e)
        {
            try
            {
                // Turn On
                await Flashlight.TurnOnAsync();

              
            }

            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}