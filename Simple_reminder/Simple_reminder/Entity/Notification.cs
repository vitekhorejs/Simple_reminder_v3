using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simple_reminder
{
    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public Category Category_ID
        {
            get => default(int);
            set
            {
            }
        }

        public Reminder Reminder_ID
        {
            get => default(int);
            set
            {
            }
        }
    }
}
