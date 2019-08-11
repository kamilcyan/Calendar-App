using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
        static private int iDaysInMonth;
        static private int dayOfFirstDay = _DisplayStartDate.Day;
        static private CultureInfo _cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.LCID);
        static private System.Globalization.Calendar sysCal;


        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            textBlockFormatting();
            startButtonFormatting();
            _cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.LCID);
            sysCal = _cultureInfo.Calendar;
            _DisplayMonth = _DisplayStartDate.Month;
            _DisplayYear = _DisplayStartDate.Year;
            iDaysInMonth = sysCal.GetDaysInMonth(_DisplayStartDate.Year, _DisplayStartDate.Month);
        }

        private void startButtonFormatting()
        {
        }


        private void textBlockFormatting()
        {
            _DisplayMonth = _DisplayStartDate.Month;
            _DisplayYear = _DisplayStartDate.Year;
            sysCal = _cultureInfo.Calendar;
            iDaysInMonth = sysCal.GetDaysInMonth(_DisplayStartDate.Year, _DisplayStartDate.Month);

            NewStackPanel2.Children.Clear();

            int fDay = FirstDayOfTheMonth();



            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < fDay - 1; j++)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Background = Brushes.White;

                    Grid.SetRow(textBlock, 0);
                    Grid.SetColumn(textBlock, j);
                    NewStackPanel2.Children.Add(textBlock);
                }

                for (int j = fDay - 1; j < 7; j++)
                {
                    var date = new DateTime(_DisplayYear, _DisplayMonth, dayOfFirstDay);
                    SingleDayPage singleDayPage = new SingleDayPage(date);

                    Grid.SetRow(singleDayPage, 0);
                    Grid.SetColumn(singleDayPage, j);
                    NewStackPanel2.Children.Add(singleDayPage);
                    dayOfFirstDay++;
                }
            }
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    var date = new DateTime(_DisplayYear, _DisplayMonth, dayOfFirstDay);

                    SingleDayPage singleDayPage = new SingleDayPage(date);

                    Grid.SetRow(singleDayPage, i);
                    Grid.SetColumn(singleDayPage, j);
                    NewStackPanel2.Children.Add(singleDayPage);

                    if (dayOfFirstDay >= iDaysInMonth)
                        return;

                    dayOfFirstDay++;
                }
            }



        }

        private static int FirstDayOfTheMonth()
        {
            int iOffsetDays = Convert.ToInt32(System.Enum.ToObject(typeof(System.DayOfWeek), _DisplayStartDate.DayOfWeek));
            return iOffsetDays;
        }

        private void MonthlyCalendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e) { }
        private void MonthlyCalendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e) { }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
