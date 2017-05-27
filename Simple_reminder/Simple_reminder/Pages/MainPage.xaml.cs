using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Simple_reminder
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            List<Category> categories = new List<Category>();
            //Category category = new Category();
            //category.Name = "Škola";

            categories.Add(new Category());
            categories.Add(new Category("Práce"));
            categories.Add(new Category("Volný čas"));

            foreach(Category item in categories )
            {
                Database.SaveItemAsync(item);
            }
            

            /*var monkeyList = new List<string>();
            monkeyList.Add("Baboon");
            monkeyList.Add("Capuchin Monkey");
            monkeyList.Add("Blue Monkey");
            monkeyList.Add("Squirrel Monkey");
            monkeyList.Add("Golden Lion Tamarin");
            monkeyList.Add("Howler Monkey");
            monkeyList.Add("Japanese Macaque");*/

            //var picker = new Picker();
            //picker.ItemsSource = monkeyList;
            //NavigationPage.SetBackButtonTitle(page, "");
        }

        private static SP_Database _database;

        public static SP_Database Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SP_Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }

        /*public void ToPage(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Page1());
        }*/
        public void Add_Button(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddPage()));
        }

        public void AddCategory_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddCategoryPage()));
            //MainPage = new NavigationPage(new Simple_reminder.MainPage());
        }
    }
}
