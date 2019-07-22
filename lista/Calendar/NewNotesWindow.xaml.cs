using Calendar.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy NewNotesWindow.xaml
    /// </summary>
    public partial class NewNotesWindow : Window
    {
       
        public NewNotesWindow()
        {
            InitializeComponent();
            DateShow.Text = DateTime.Now.ToString();
            TextBlockPreparation();
        }

        private void TextBlockPreparation()
        {
            ShowNotes.Text = "This text";
            string date = DateTime.Now.ToString();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            using (CalendarDbContext db = new CalendarDbContext())

            {
                db.Notes.Add(new Note() { Body = InsertNote.Text, DateOfPosting = DateTime.Now });

                db.SaveChanges();

                this.Close();
            }
        }

        public void GoShowNotes()
        {
            CalendarDbContext db = new CalendarDbContext();
            Note note = new Note();

            Console.WriteLine(note.Body);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
