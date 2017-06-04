﻿using System;
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
            //GetItemsToListView();


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

        public void OnPickerChanged(Object sender, EventArgs e)
        {
            Category category = picker.SelectedItem as Category;
            if (category.Name == "Vše")
            {
                //DependencyService.Get<IPopUp>().ShowToast("vše");
                List<Reminder> itemsFromDb = Database.GetRemindersAsync().Result;
                ListView.ItemsSource = itemsFromDb;
            }
            else
            {
                
                //DependencyService.Get<IPopUp>().ShowToast(category.SelectedItem.ToString());
                List<Reminder> itemsFromDb = Database.GetReminderByCategoryId(category.Id).Result;
                ListView.ItemsSource = itemsFromDb;
            }
            
        }

        public void Add_Button(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddPage()));
        }

        public void Category_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new CategoryPage()));
        }

        private void GetItemsToListView()
        {
            List<Reminder> itemsFromDb = Database.GetRemindersAsync().Result;
            ListView.ItemsSource = itemsFromDb;
        }

        private void GetItemsToPicker()
        {
            List<Category> itemsFromDb = Database.GetCategoriesAsync().Result;
            /*var CategoryList = new List<string>();
            foreach (Category item in itemsFromDb)
            {
                CategoryList.Add(item.Name);
            }*/
            Category category = new Category();
            category.Name = "Vše";
            itemsFromDb.Insert(0, category);
            picker.ItemsSource = itemsFromDb;
            picker.SelectedIndex = 0;
        }

        private void EditReminder(object sender, ItemTappedEventArgs e)
        {
            // Navigation.PushModalAsync(new DetailPage(e.Item as Contact));
            Navigation.PushModalAsync(new NavigationPage(new AddPage(e.Item as Reminder)));

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
