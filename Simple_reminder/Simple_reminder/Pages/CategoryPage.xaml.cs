using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simple_reminder
{
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
            GetItemsToListView();
        }

        private static SR_Database _database;

        public static SR_Database Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SR_Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("SR_database.db3"));
                }
                return _database;
            }
        }

        private void GetItemsToListView()
        {
            List<Category> itemsFromDb = Database.GetCategoriesAsync().Result;
            ListView.ItemsSource = itemsFromDb;
        }

        public void Back_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }

        public void AddCategory_Button(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddCategoryPage()));
        }

        private void EditCategory(object sender, ItemTappedEventArgs e)
        {
            // Navigation.PushModalAsync(new DetailPage(e.Item as Contact));
            Navigation.PushModalAsync(new NavigationPage(new AddCategoryPage(e.Item as Category)));

        }
    }
}
