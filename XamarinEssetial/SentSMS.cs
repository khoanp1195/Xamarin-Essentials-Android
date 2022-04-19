using Android;
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
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinEssetial
{
    [Activity(Label = "SentSms")]
    public class SentSms : Activity
    {

        TextView phone;
        EditText message;
        ImageView back;
        Button sent;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.sentSMS);
            // Create your application here

            message = FindViewById<EditText>(Resource.Id.editText1);
            sent = FindViewById<Button>(Resource.Id.sent);
            sent.Click += Sent_Click;

            phone = FindViewById<TextView>(Resource.Id.number);


        }

        [Obsolete]

        public class SmsTest
        {
            public async Task SendSms(string messageText, string[] recipients)
            {
                try
                {
                    var message = new Xamarin.Essentials.SmsMessage(messageText, recipients);
                    await Sms.ComposeAsync(message);
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Sms is not supported on this device.
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            }
        }
        private async void Sent_Click(object sender, EventArgs e)
        {
            string phonenumber = phone.Text;
            string contentmessage = message.Text;

            try
            {
                await Sms.ComposeAsync(new SmsMessage(phonenumber, contentmessage));
            }
            catch(Exception)
            {

            }
                
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}