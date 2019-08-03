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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Calendar.Classes;
using System.Globalization;


namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static internal System.DateTime _DisplayStartDate = System.DateTime.Now.AddDays(-1 * (System.DateTime.Now.Day - 1));
        static private int _DisplayMonth;
        static private int _DisplayYear;
        static private int dayOfFirstDay = _DisplayStartDate.Day;
        static private System.Globalization.Calendar sysCal;


        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            textBlockFormatting();
            startButtonFormatting();

        }

        private void startButtonFormatting()
        {
        }

        public DateTime DisplayStartDate
        {
            get { return _DisplayStartDate; }
            set
            {
                _DisplayStartDate = value;
                _DisplayMonth = _DisplayStartDate.Month;
                _DisplayYear = _DisplayStartDate.Year;
            }
        }


        static private int iDaysInMonth = sysCal.GetDaysInMonth(_DisplayStartDate.Year, _DisplayStartDate.Month);

        private void textBlockFormatting()
        {
            int counter = 1;
            for (int i=0; i<5; i++)
            {
                for(int j=0; j<7; j++)
                {
                    DateTime dt = new DateTime();
                    
                    _DisplayMonth = _DisplayStartDate.Month;
                    _DisplayYear = _DisplayStartDate.Year;

                    List<Note> notes;
                    var date = new DateTime(_DisplayYear, _DisplayMonth, counter);

                    using (CalendarDbContext context = new CalendarDbContext())
                    {
                        var tomorrow = date.AddDays(1);
                        notes = context.Notes.Where(x => x.DateOfPosting > date && x.DateOfPosting < tomorrow).ToList();
                    }
                    SingleDayPage singleDayPage = new SingleDayPage(notes, date);
                    //SingleDayWindow singleDayWindow = new SingleDayWindow(notes, date);
                    
                    Grid.SetRow(singleDayPage, i);
                    Grid.SetColumn(singleDayPage, j);
                    NewStackPanel2.Children.Add(singleDayPage);
                    dayOfFirstDay++;
                    
                }
            }

            
        }
        

        private void MonthlyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            NewNotesWindow newNotesWindow = new NewNotesWindow();
            newNotesWindow.Show();
        }
        private void MonthlyCalendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e) { }
        private void MonthlyCalendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e) { }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
