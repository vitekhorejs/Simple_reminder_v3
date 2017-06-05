using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Linq;
using Xamarin.Forms;

namespace Simple_reminder.Droid
{
    [Activity(Label = "Simple_reminder", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity /*ActionBarActivity*/
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        /*private double _backPressTime = 0;

        public override void OnBackPressed()
        {

            //Toast.MakeText(this, Android.App.Application.Context.ToString(), ToastLength.Short);
            if (App.IsMainPage == true)
            {
                
                double t = new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds;

                if (t - _backPressTime > 2000) // i.e. 2000 milliseconds
                {
                    _backPressTime = t;
                    Toast.MakeText(this, "Stiskněte znovu pro ukončení", ToastLength.Short)
                        .Show();
                }
                else
                {
                    base.OnBackPressed(); // now we can quit
                }
            }
            else
            {
                base.OnBackPressed();
            }
            
        }*/
    }
}

