using Calendar.DataAccess;
using System;
using System.Linq;
using System.Windows;

namespace Calendar
{
    public partial class AddNoteWindow : Window
    {
        NotesDataAccess dataAccess;
        public AddNoteWindow()
        {
            InitializeComponent();
             dataAccess = new NotesDataAccess();
        }
        
        private Note note { get; }

        public AddNoteWindow(DateTime date) : this()
        {
            note = new Note();
            note.DateOfPosting = date;
            AddNoteWindowFormatting();
        }
        public AddNoteWindow(Note note) : this()
        {
            this.note = note;
            AddNoteWindowFormatting();
        }

        private void AddNoteWindowFormatting()
        {
            Hour.Text = note.Hour.Split(':')[0];
            Minute.Text = note.Hour.Split(':')[1];
            NewNote.Text = note.Body;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            note.Body = NewNote.Text;
            note.DateOfPosting = new DateTime(note.DateOfPosting.Year, note.DateOfPosting.Month, note.DateOfPosting.Day, int.Parse(Hour.Text), int.Parse(Minute.Text),0);
            dataAccess.AddOrUpdate(note);

            this.Close();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.Remove(note);
            this.Close();
        }
    }
}
