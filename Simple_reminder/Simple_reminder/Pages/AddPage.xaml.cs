using Plugin.LocalNotifications;
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
            deleteButton.IsVisible = false;
        }

        public AddPage(Reminder reminder)
        {
            InitializeComponent();
            obj = reminder;
            Id = reminder.Id;
            name.Text = reminder.Name;
            Cat_Id = reminder.Category_Id;
            Date.Date = reminder.DateTime;
            Time.Time = reminder.DateTime.TimeOfDay;
            Description.Text = reminder.Description;
            switch_allowed.IsToggled = reminder.Allowed;
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
            { }
        }

        private void GetItemsToPicker()
        {
            var itemsFromDb = Database.GetCategoriesAsync().Result;
            Category.ItemsSource = itemsFromDb;
            if (Cat_Id.Equals(0))
            { }
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
                    { }
                    else
                    {
                        reminder.Id = Id;
                    }
                    reminder.Name = name.Text;
                    reminder.Category_Id = neco.Id;
                    reminder.Description = Description.Text;
                    reminder.DateTime = Date.Date + Time.Time;
                    if (switch_allowed.IsToggled == true)
                    {
                        reminder.Allowed = true;
                        CrossLocalNotifications.Current.Show(reminder.Name, reminder.Description, reminder.Id, reminder.DateTime);
                    } else
                    {
                        reminder.Allowed = false;
                        CrossLocalNotifications.Current.Cancel(reminder.Id);
                    }
                    Database.SaveItemAsync(reminder);
                    DependencyService.Get<IPopUp>().ShowToast("Událost uložena");
                    Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                }
                //DependencyService.Get<IPopUp>().ShowToast(reminder.DateTime.ToString("HH:mm d. MMMM, yyyy"));
            }
        }

        public void Back_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}
