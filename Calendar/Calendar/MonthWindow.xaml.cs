using System;
using System.Windows;
using System.Windows.Controls;
using Calendar.DataAccess;
using Calendar.EventHandler;

namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy SingleDayPage.xaml
    /// </summary>
    public partial class MonthWindow : UserControl, IDisposable
    {
        Subscriber<int> subscriber;

#pragma warning disable IDE1006 // Style nazewnictwa
        private void update(object sender, DateChangedArgument<int> e)
#pragma warning restore IDE1006 // Style nazewnictwa
        {
            _date = new DateTime(_date.Year, e.Message, 1);
            Load();
        }

        NotesDataAccess dataAccess = new NotesDataAccess();
        DateTime _date;
        public MonthWindow(DateTime date)
        {
            InitializeComponent();
            _date = date;
            subscriber = new Subscriber<int>(update);

            Load();
        }

        public MonthWindow() : this(DateTime.Now)
        { }
        private void Load()
        {
            DateTime firstDayOfMonth = _date.AddDays(-_date.Day);
            var offset = (int)firstDayOfMonth.DayOfWeek - 1;
            for (int i = 0; i < 35; i++)
            {
                var day = firstDayOfMonth.AddDays(i - offset);
                SingleDayPage singleDayPage = new SingleDayPage(day.Date, day.Month == _date.Month);

                Grid.SetRow(singleDayPage, i / 7);
                Grid.SetColumn(singleDayPage, i % 7);
                NewStackPanel2.Children.Add(singleDayPage);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var data = new Test { Test1 = "Test1", Test2 = "Test2" };

            //NewStackPanel2.Items.Add(data);
        }


        public void Dispose()
        {
            subscriber.Dispose();
        }
        public class Test
        {
            public string Test1 { get; set; }
            public string Test2 { get; set; }
        }
    }
}
