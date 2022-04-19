using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace XamarinEssetial
{
    [Activity(Label = "sharefiles")]
    public class sharefiles : Activity
    {
        Button btnshare, btnsharefile;
        EditText editText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sharefile);
            // Create your application here



            btnshare = FindViewById<Button>(Resource.Id.share);
            btnshare.Click += Btnshare_Click;

            btnsharefile = FindViewById<Button>(Resource.Id.sharefile);
            btnsharefile.Click += Btnsharefile_Click;

            editText = FindViewById<EditText>(Resource.Id.editText1);
        }

        private async void Btnsharefile_Click(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest

            {
                Text = editText.Text,
                Title = "Share"
            }

                );
        }

        private async void Btnshare_Click(object sender, EventArgs e)
        {
            var info = editText.Text;
            if (string.IsNullOrWhiteSpace(info))
                return;
            var path = string.Empty;
            path = Path.Combine(FileSystem.CacheDirectory, "khoa.txt");
            File.WriteAllText(path, info);

            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Hello anh Khoa",
                File = new ShareFile(path)
            }
                );
        }
    }
}