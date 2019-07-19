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
    /// <summary>
    /// Logika interakcji dla klasy NewNotesWindow.xaml
    /// </summary>
    public partial class NewNotesWindow : Window
    {
        public NewNotesWindow()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            CalendarDbContext db = new CalendarDbContext();

            db.Notes.Add(new Note() { Body = Console.ReadLine() });

            db.SaveChanges();

            this.Close();
        }
    }
}
