using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Image = System.Drawing.Image;

namespace XamarinEssetial
{
    [Activity(Label = "screenshot", MainLauncher = false)]
    public class screenshot : Activity
    {
       Button btntakephoto;
        ImageView image;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.screenshot);
            // Create your application here


            btntakephoto = FindViewById<Button>(Resource.Id.takephoto);
            btntakephoto.Click += Btntakephoto_Click;



            ImageView imageView = FindViewById<ImageView>(Resource.Id.image);
        }

        private void Btntakephoto_Click(object sender, EventArgs e)
        {
            CaptureScreenshot();
        }
     
        public byte[] CaptureScreenshot()
        {
            var view =
                Xamarin.Essentials.Platform.CurrentActivity.Window.DecorView.RootView;

            if (view.Height < 1 || view.Width < 1)
                return null;

            byte[] buffer = null;

            view.DrawingCacheEnabled = true;

            using (var screenshot = Android.Graphics.Bitmap.CreateBitmap(
                view.Width,
                view.Height,
                Android.Graphics.Bitmap.Config.Argb8888))
            {
                var canvas = new Canvas(screenshot);


                view.Draw(canvas);

                using (var stream = new MemoryStream())
                {
                    screenshot.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 90, stream);
                    buffer = stream.ToArray();
                }
            }

            view.DrawingCacheEnabled = false;

            return buffer;

        }
    }
}