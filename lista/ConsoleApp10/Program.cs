using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {


            
            Menu();

            Console.ReadKey();
        }

        private static void Menu()
        {
            Console.WriteLine("Choose action:\n1.\tAdd note\n2.\tFind note\n3.\tUpdate note\n4.\tRemove note\n5.\tEnd program");

            char choise;

            char.TryParse(Console.ReadLine(), out choise);

            switch (choise)
            {
                case '1':
                    AddItem();
                    break;
                case '2':
                    FindItem();
                    break;
                case '3':
                    UptadeItem();
                    break;
                case '4':
                    RemoveItem();
                    break;
                default:
                    break;
            }
        }

        private static void RemoveItem()
        {
            AppDbContext db = new AppDbContext();
            Note note = db.Notes.Find(1);
            db.Notes.Remove(note);
            db.SaveChanges();
            Console.WriteLine("Record removed succesfully");
            Menu();
        }

        private static Note UptadeItem()
        {
            AppDbContext db = new AppDbContext();
            Note note = db.Notes.Find(1);
            note.Body = "Call to Ramesh";
            db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
            Console.WriteLine("Record updated succesfully");
            Menu();
            return note;
        }

        private static Note FindItem()
        {
            AppDbContext db = new AppDbContext();
            Note note = new Note();
            int x = note.Id;
            note = db.Notes.Find(x);
            Console.WriteLine("Id : " + note.Id);
            Console.WriteLine("Note : " + note.Body);
            Console.WriteLine("Record read succesfully");
            Menu();
            return note;
        }

        private static void AddItem()
        {
            
            AppDbContext db = new AppDbContext();
            Console.WriteLine("Write..");
            db.Notes.Add(new Note() { Body = Console.ReadLine() });
            db.SaveChanges();
            Console.WriteLine("Record added succesfully");
            Menu();
            
        }


        public class Note
        {
            public int Id { get; set; }
            public string Body { get; set; }

        }

        public class AppDbContext : DbContext
        {
            public DbSet<Note> Notes { get; set; }
        }
    }
}
