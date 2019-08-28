using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Calendar.DataAccess;
using Calendar.EventHandler;

namespace Calendar
{
    public partial class SingleDayPage : UserControl
    {
        private readonly Subscriber<DateTime> subscriber;
        NotesDataAccess dataAccess = new NotesDataAccess();
        DateTime _date;

        public bool IsThisMonth { get; }

        public SingleDayPage(DateTime date, bool isThisMonth)
        {
            _date = date.Date;
            InitializeComponent();


            IsThisMonth = isThisMonth;
            Update();
            subscriber = new Subscriber<DateTime>(OnUpdate);
        }
        public SingleDayPage() : this(DateTime.Now, true)
        { }
        public void Update()
        {
            List<Note> notes = dataAccess.GetNotesForDay(_date);

            var viewModel = new SingleDayViewModel(notes, _date, IsThisMonth);
            tStack.DataContext = viewModel;
            DataContext = viewModel;
        }

        private void OnUpdate(object sender, DateChangedArgument<DateTime> e)
        {
            if (e.Message.Equals(_date))
            {
                Update();
            }
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            AddNoteWindow addNoteWindow = new AddNoteWindow(_date);
            addNoteWindow.ShowDialog();
            subscriber.PublishData(new DateChangedArgument<DateTime>(_date));
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            var note = ((dynamic)sender).DataContext as Note;
            AddNoteWindow addNoteWindow = new AddNoteWindow(note);
            addNoteWindow.ShowDialog();
            subscriber.PublishData(new DateChangedArgument<DateTime>(_date));
        }
    }
}
