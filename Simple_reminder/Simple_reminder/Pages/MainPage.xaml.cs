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
            InitDB();
            GetItemsToPicker();

            
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

        public void Add_Button(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddPage()));
        }

        public void AddCategory_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddCategoryPage()));
        }

        private void GetItemsToPicker()
        {
            List<Category> itemsFromDb = Database.GetCategoriesAsync().Result;
            //ListView.ItemsSource = itemsFromDb;
            var CategoryList = new List<string>();
            foreach (Category item in itemsFromDb)
            {
                //item.Name
                CategoryList.Add(item.Name);
            }
            CategoryList.Insert(0, "Vše");
            picker.ItemsSource = CategoryList;
            picker.SelectedIndex = 0;
            

        }

        private void GetContact(object sender, ItemTappedEventArgs e)
        {
           // Navigation.PushModalAsync(new DetailPage(e.Item as Contact));
        }

        public void InitDB()
        {
            var itemsFromDb = Database.GetCategoriesAsync().Result;
            if (itemsFromDb.Count() == 0)
            {
                Category category1 = new Category();
                category1.Name = "Škola";
                Database.SaveItemAsync(category1);

                Category category2 = new Category();
                category2.Name = "Práce";
                Database.SaveItemAsync(category2);

                Category category3 = new Category();
                category3.Name = "Volný čas";
                Database.SaveItemAsync(category3);
            }
        }      
    }
}
