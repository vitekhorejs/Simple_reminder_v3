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
        public int Id;
        public AddPage()
        {
            InitializeComponent();
            GetItemsToPicker();
            Time.Time = DateTime.Now.TimeOfDay;
        }
        public AddPage(Reminder reminder)
        {
            InitializeComponent();
            GetItemsToPicker();
            //obj = book;
            Id = reminder.Id;
            name.Text = reminder.Name;
            Category.SelectedItem = reminder.Category_Id;
            Date.Date = reminder.DateTime;
            Time.Time = reminder.DateTime.TimeOfDay;
            Description.Text = reminder.Description;
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

        private void GetItemsToPicker()
        {
            /*List<Category> itemsFromDb = Database.GetCategoriesAsync().Result;
            var CategoryList = new List<string>();
            foreach (Category item in itemsFromDb)
            {
                CategoryList.Add(item.Name);
            }
            //CategoryList.Insert(0, "Vše");
            Category.ItemsSource = CategoryList;
            Category.SelectedIndex = 0;*/

            var itemsFromDb = Database.GetCategoriesAsync().Result;
            Category.ItemsSource = itemsFromDb;
        }

        public void Save_Clicked(Object sender, EventArgs e)
        {
            
            if (Category.SelectedItem == null)
            {
                DependencyService.Get<IPopUp>().ShowToast("Vyberte Kategorii");
            }
            else
            {
                if (name.Text == "" || name.Text == null)
                {
                    DependencyService.Get<IPopUp>().ShowToast("Vyplňte název události");
                }
                else
                {
                    Category neco = Category.SelectedItem as Category;
                    Reminder reminder = new Reminder();
                    reminder.Name = name.Text;
                    reminder.Category_Id = neco.Id;
                    reminder.Description = Description.Text;
                    reminder.DateTime = Date.Date + Time.Time;
                    Database.SaveItemAsync(reminder);
                    DependencyService.Get<IPopUp>().ShowToast("Událsot uložena");
                    Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                }
                


                //DependencyService.Get<IPopUp>().ShowToast(reminder.DateTime.ToString("HH:mm d. MMMM, yyyy"));
            }



            //DependencyService.Get<IPopUp>().ShowToast(neco.Id.ToString());

            //var itemsFromDb = Database.GetCategoryById(neco.Id).Result;
            //DescriptionLabel.Text = itemsFromDb.Name;



            //string categoryId = Category.Items[Category.SelectedIndex];
            //name.Text = categoryId;

            //Database.SaveItemAsync(category1);



        }

        public void Back_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}
