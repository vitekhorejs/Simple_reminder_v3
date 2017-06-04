using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace Simple_reminder
{
    public class SR_Database
    {
        private SQLiteAsyncConnection database;

        public SR_Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Category>().Wait();
            database.CreateTableAsync<Reminder>().Wait();
            database.CreateTableAsync<Notification>().Wait();
        }

        public Task<List<Reminder>> GetRemindersAsync()
        {
            return database.Table<Reminder>().ToListAsync();
        }
        public Task<List<Category>> GetCategoriesAsync()
        {
            return database.Table<Category>().ToListAsync();
        }
        public Task<List<Notification>> GetNotificationsAsync()
        {
            return database.Table<Notification>().ToListAsync();
        }


        public Task<int> SaveItemAsync(Category item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsync(Reminder item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsync(Notification item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<Category> GetCategoryById(int Id)
        {
            return database.Table<Category>().Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteItemAsync(Reminder item)
        {
            return database.DeleteAsync(item);
        }
    }
}
