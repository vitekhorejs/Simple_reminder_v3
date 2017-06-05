using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Simple_reminder
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //List<Category> categories = new List<Category>;
            
            

            MainPage = new NavigationPage(new Simple_reminder.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        /*public static bool IsRootPage { get; set{ } }
        public void IsRootPageMethod()
        {
            var name = this.GetType().Name;
            if (name == "MainPage")
            {
                IsRootPage = true;
            }
            else
            {
                IsRootPage = false;
            }
        }*/

        /*private bool isMainPage()
        {
            //Navigation
            //var name = this.GetType().Name;
            var page = App.Navigation.NavigationStack.Last();
            //return page.Title;
            if (name == "MainPage")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsMainPage
        {
            get
            {
                App mp = new App();
                return mp.isMainPage();
            }
            set
            {
                IsMainPage = value;
            }
        }*/
    }
}
