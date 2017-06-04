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
        public int Cat_Id;
        public Reminder obj;
        public Category itemsFromDb;

        public AddPage()
        {
            InitializeComponent();
            GetItemsToPicker();
            Time.Time = DateTime.Now.TimeOfDay;
        }
        public AddPage(Reminder reminder)
        {
            InitializeComponent();
            
            obj = reminder;
            Id = reminder.Id;
            name.Text = reminder.Name;
            Cat_Id = reminder.Category_Id;
           // itemFromDb = Database.GetCategoryById(reminder.Category_Id).Result;


            //Category.SelectedItem = itemFromDb.GetName;
            //Category.SelectedItem = itemsFromDb.Where(p => p.ProjectID == 2).First();
            Date.Date = reminder.DateTime;
            Time.Time = reminder.DateTime.TimeOfDay;
            Description.Text = reminder.Description;
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

        async private void Delete_Button(object sender, EventArgs e)
        {
            var ans = await DisplayAlert("Upozornění", "Opravdu chcete smazat tuto událost", "Ano", "Ne");
            if (ans.Equals(true))
            {
                await Database.DeleteItemAsync(obj as Reminder);
                DependencyService.Get<IPopUp>().ShowToast("Událost smazána");
                await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
            else
            {

            }
            //Database.DeleteItemAsync(obj as Reminder);
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
            if (Cat_Id.Equals(0))
            {

            }
            else
            {
                Category.SelectedItem = itemsFromDb.Where(p => p.Id == Cat_Id).First();
            }
            
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
                    if (Id.Equals(null))
                    {

                    }
                    else
                    {
                        reminder.Id = Id;
                    }
                    reminder.Name = name.Text;
                    reminder.Category_Id = neco.Id;
                    reminder.Description = Description.Text;
                    reminder.DateTime = Date.Date + Time.Time;
                    Database.SaveItemAsync(reminder);
                    DependencyService.Get<IPopUp>().ShowToast("Událost uložena");
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
