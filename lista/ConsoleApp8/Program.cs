using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp8
{


    class Program
    {
        static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();
            db.Notes.Add(new Note() { Title = "Zadzwonic" });
            db.SaveChanges();
            Console.WriteLine("Record added succesfully");
        }
    }

    class Note
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    class AppDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
    }
}
