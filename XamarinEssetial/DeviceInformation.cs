using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace XamarinEssetial
{
    [Activity(Label = "DeviceInformation")]
    public class DeviceInformation : Activity
    {

        TextView txtDevice;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DeviceInformation);

            txtDevice = (TextView)FindViewById(Resource.Id.txtDevice);

            // Device Model (SMG-950U, iPhone10,6)
            var device = DeviceInfo.Model;

            // Manufacturer (Samsung)
            var manufacturer = DeviceInfo.Manufacturer;

            // Device Name (Motz's iPhone)
            var deviceName = DeviceInfo.Name;

            // Operating System Version Number (7.0)
            var version = DeviceInfo.VersionString;

            // Platform (Android)
            var platform = DeviceInfo.Platform;

            if(platform == DevicePlatform.Android)
            {
                //android
            }

            // Idiom (Phone)
            var idiom = DeviceInfo.Idiom;
            if(idiom  == DeviceIdiom.Tablet)
            {

            }


            // Device Type (Physical)
            var deviceType = DeviceInfo.DeviceType;


            txtDevice.Text = $"{deviceName} {version} {platform}";
        }
    }
}