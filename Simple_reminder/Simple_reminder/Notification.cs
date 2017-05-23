using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simple_reminder
{
    class Notification
    {
        [PrimaryKey, AutoIncrement]
        int Id { get; set; }
        string Name { get; set; }
        string Text { get; set; }

    }
}
