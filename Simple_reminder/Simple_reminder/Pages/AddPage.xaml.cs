using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simple_reminder
{
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
            Description.HeightRequest = 50;
        }

        public void Save_Clicked(Object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new AddPage());

        }

        public void Back_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}
