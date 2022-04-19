using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace XamarinEssetial
{
    [Activity(Label = "ThemeDetection")]
    public class ThemeDetection : Activity
    {
        Button theme;
        LinearLayout linearLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ThemeDetection);

            // Create your application here

            linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout1);

            theme = FindViewById<Button>(Resource.Id.themedetection);
            theme.Click += Theme_Click;
        }

        private void Theme_Click(object sender, EventArgs e)
        {
            var currentTheme = AppInfo.RequestedTheme;
            var theme = $"Theme is  {currentTheme}";

            Snackbar.Make(linearLayout, "Current Theme is: " + theme , Snackbar.LengthShort).Show();
        }
    }
}