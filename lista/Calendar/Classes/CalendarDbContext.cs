﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Calendar.Classes
{
    class CalendarDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
    }

}
