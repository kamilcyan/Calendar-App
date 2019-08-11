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

namespace Calendar
{
    public partial class AddNoteWindow : Window
    {
        public AddNoteWindow()
        {
            InitializeComponent();
            AddNoteWindowFormatting();
        }

        DateTime _date;

        public AddNoteWindow(DateTime date) : this()
        {
            _date = date;
        }

        private void AddNoteWindowFormatting()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Name = "NewStackPanel";


            Button button1 = new Button();
            button1.Name = "SaveButton";
            button1.Content = "Save";
            button1.VerticalAlignment = VerticalAlignment.Center;
            button1.HorizontalAlignment = HorizontalAlignment.Left;
            button1.Height = 50;
            button1.Width = 70;
            button1.Click += new RoutedEventHandler(SaveButton_Click);
            NewStackPanel.Children.Add(button1);

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (CalendarDbContext db = new CalendarDbContext())
            {
                db.Notes.Add(new Note() { Body = NewNote.Text, DateOfPosting = _date });
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
