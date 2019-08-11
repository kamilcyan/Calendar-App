using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Calendar.DataAccess;

namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy SingleDayPage.xaml
    /// </summary>
    public partial class SingleDayPage : UserControl
    {
        NotesDataAccess dataAccess = new NotesDataAccess();
        DateTime _date;
        public SingleDayPage(DateTime date)
        {

            _date = date;
            InitializeComponent();

            Update();

        }

        public void Update()
        {
            List<Note> notes = dataAccess.GetNotesForDay(_date);

            var viewModel = new SingleDayViewModel(notes, _date);
            tStack.DataContext = viewModel;
            DataContext = viewModel;
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            AddNoteWindow addNoteWindow = new AddNoteWindow(_date);
            addNoteWindow.ShowDialog();
            Update();
        }
        private void xx(object sender, RoutedEventArgs e)
        {
            AddNoteWindow addNoteWindow = new AddNoteWindow(((dynamic)sender).DataContext as Note);
            addNoteWindow.ShowDialog();
            Update();
        }

       
    }
}
