using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V4.View;

using System;
using Android.Graphics;
using Android;
using Android.Support.V4.App;

using Android.Media;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Content;


namespace XamarinEssetial
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher =true)]
    public class MainActivity2 : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private DrawerLayout mDrawerLayout;

        MediaPlayer endSong, click;

        public static Context GetContext;

    

      
        //PermissionRequest
        const int RequestID = 0;
        readonly string[] permissionsGroup =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation,
        };

        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main2);

          
            CheckSpecialPermission();


            //GetContext = this;
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
           
            //Configuration config = GetContext.Resources.Configuration;
            //var ThemeMode = config.UiMode == (UiMode.NightYes | UiMode.TypeNormal);
            //if (ThemeMode) GetContext.SetTheme(Resource.Style.DarkTheme);
            //else GetContext.SetTheme(Resource.Style.LightTheme);



            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);

            SupportActionBar ab = SupportActionBar;
            ab.SetHomeAsUpIndicator(Resource.Drawable.menu16);
            ab.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            
            }

            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                Android.App.FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                if (e.MenuItem.ItemId == Resource.Id.nav_feedback)
                {
                    Intent intent = new Intent(this, typeof(ThemeDetection));
                    StartActivity(intent);
                }
                else if (e.MenuItem.ItemId == Resource.Id.nav_aboutus)
                {
                    Intent intent = new Intent(this, typeof(RegisterActivity));
                    StartActivity(intent);

                }
                else if(e.MenuItem.ItemId == Resource.Id.nav_aboutapp)
                {
                    //MGradeFragment mg = new MGradeFragment();
                    //// The fragment will have the ID of Resource.Id.fragment_container.
                    //ft.Replace(Resource.Id.ll, mg);
                    Intent email = new Intent(Intent.ActionSend);
                    email.PutExtra(Intent.ExtraEmail, new String[] { "zphuongkhoaz@gmail.com" });
                    email.PutExtra(Intent.ExtraSubject, "Feedback for app");
                    email.PutExtra(Intent.ExtraText, "");
                    email.SetType("message/rfc822");
                    StartActivity(Intent.CreateChooser(email, "Sent Email"));
                }
                else if (e.MenuItem.ItemId == Resource.Id.nav_feedback)
                {
                    
                }


                else if (e.MenuItem.ItemId == Resource.Id.nav_flashlight)
                {
                    Intent intent = new Intent(this, typeof(flashlight));
                    StartActivity(intent);
                }
                else if (e.MenuItem.ItemId == Resource.Id.nav_deviceinfo)
                {
                    Intent intent = new Intent(this, typeof(DeviceInformation));
                    StartActivity(intent);
                }
                else if (e.MenuItem.ItemId == Resource.Id.nav_sharefile)
                {
                    Intent intent = new Intent(this, typeof(sharefiles));
                    StartActivity(intent);
                }
                else if (e.MenuItem.ItemId == Resource.Id.nav_sentSMS)
                {
                    Intent intent = new Intent(this, typeof(SentSms));
                    StartActivity(intent);
                }


                //...

                // Commit the transaction.
                ft.Commit();
                mDrawerLayout.CloseDrawers();
            
            };
      
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return true;
        }




        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                e.MenuItem.SetChecked(true);
                mDrawerLayout.CloseDrawers();
            };
        }

            bool NavigationView.IOnNavigationItemSelectedListener.OnNavigationItemSelected(IMenuItem menuItem)
        {
            
            int id = menuItem.ItemId;

            if (id == Resource.Id.nav_home)
            {
                // Handle the camera action
            }
            else if (id == Resource.Id.nav_aboutus)
            {
                
            }
          
            else if (id == Resource.Id.nav_feedback)
            {
               
            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;

        }

      

      

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

               

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }


        bool CheckSpecialPermission()
        {
            bool permissionGranted = false;
            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted &&
                ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted)
            {
                RequestPermissions(permissionsGroup, RequestID);
            }
            else
            {
                permissionGranted = true;
            }

            return permissionGranted;
        }

    }
}