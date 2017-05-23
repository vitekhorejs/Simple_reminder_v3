﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Simple_reminder
{
    class Reminder
    {
        [PrimaryKey, AutoIncrement]
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Category { get; set; }
        
    }
}
