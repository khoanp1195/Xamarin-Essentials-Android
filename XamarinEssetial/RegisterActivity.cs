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

using System.Text.RegularExpressions;
using Android.Util;
using Google.Android.Material.Snackbar;
using AndroidX.ConstraintLayout.Widget;

using Java.Util;
using Xamarin.Essentials;

namespace XamarinEssetial
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText fullname, email, password, phone;
        Button btnRegister;
        TextView signin;

        ConstraintLayout registerLayout;
        string fullName, Email, Password, Phone;

        ISharedPreferences preferences = Application.Context.GetSharedPreferences("userInfo", FileCreationMode.Private);
        ISharedPreferencesEditor editor;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);
            ConnectControl();

          
         
      

            // Create your application here
        }


       


        void ConnectControl()
        {
            fullname = (EditText)FindViewById(Resource.Id.editName);
            email = (EditText)FindViewById(Resource.Id.edt_email);
            signin = (TextView)FindViewById(Resource.Id.signin);
        
            password = (EditText)FindViewById(Resource.Id.edt_password);
            phone = (EditText)FindViewById(Resource.Id.edt_phone);
            registerLayout = (ConstraintLayout)FindViewById(Resource.Id.register_layout);
            btnRegister = (Button)FindViewById(Resource.Id.button);
            btnRegister.Click += btnRegisterClick;
        }

      

        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }

        private void btnRegisterClick(object sender, EventArgs e)
        {
          
            fullName = fullname.Text;
            Email = email.Text;
            Password = password.Text;
            Phone = phone.Text;

            if(fullName.Length <6)
            {
                Snackbar.Make(registerLayout, "Please Enter FullName >6 ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }

            else if (Phone.Length < 6)
            {
                Snackbar.Make(registerLayout, "Sorry Please Again ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
            else if(!Email.Contains('@'))
            {
                Snackbar.Make(registerLayout, "Sorry Please Enter Email Have @ ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
            else if(Password.Length < 6)
            {
                Snackbar.Make(registerLayout, "Sorry Please Again ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
      ;
         
        }

      

     

    }
    }
