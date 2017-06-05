using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simple_reminder
{
    public partial class AddCategoryPage : ContentPage
    {
        public Category obj;
        public int Id;
        public AddCategoryPage()
        {
            InitializeComponent();
            deleteButton.IsVisible = false;
        }

        public AddCategoryPage(Category category)
        {
            InitializeComponent();
            obj = category;
            Id = category.Id;
            name.Text = category.Name;
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

        public void SaveCategory_Clicked(Object sender, EventArgs e)
        {
            if (name.Text == "" || name.Text == null)
            {
                DependencyService.Get<IPopUp>().ShowToast("Vyplňte název Kategorie");
            }
            else
            {
                //Category neco = Category.SelectedItem as Category;
                Category category = new Category();
                if (Id.Equals(null))
                { }
                else
                {
                    category.Id = Id;
                }
                category.Name = name.Text;
                Database.SaveItemAsync(category);
                DependencyService.Get<IPopUp>().ShowToast("Kategorie uložena");
                Navigation.PushModalAsync(new NavigationPage(new CategoryPage()));
            }
        }

        public void Back_Clicked(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new CategoryPage()));
        }

        async private void Delete_Button(object sender, EventArgs e)
        {
            var ans = await DisplayAlert("Upozornění", "Opravdu chcete smazat tuto kategorii", "Ano", "Ne");
            if (ans.Equals(true))
            {
                var itemsFromDb = Database.GetReminderByCategoryId(Id).Result;
                if (itemsFromDb.Count == 0)
                {
                    await Database.DeleteItemAsync(obj as Category);
                    DependencyService.Get<IPopUp>().ShowToast("Kategorie smazána");
                    await Navigation.PushModalAsync(new NavigationPage(new CategoryPage()));
                }
                else
                {
                    await DisplayAlert("Upozornění", "Nelze smazat kategorii, ke které jsou přiřazeny události", "Rozumím");
                }              
            }
            else
            { }
        }
    }
}
