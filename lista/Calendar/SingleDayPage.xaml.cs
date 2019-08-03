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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calendar.Classes;

namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy SingleDayPage.xaml
    /// </summary>
    public partial class SingleDayPage : UserControl
    {
        public SingleDayPage(List<Note> notes, DateTime date)
        {
            var viewModel = new SingleDayViewModel(notes, date);
            DataContext = viewModel;
            InitializeComponent();
        }

        
        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            AddNoteWindow addNoteWindow = new AddNoteWindow();
            addNoteWindow.ShowDialog();
        }
    }
}
