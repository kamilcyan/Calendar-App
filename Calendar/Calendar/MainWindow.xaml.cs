using Calendar.EventHandler;
using System;
using System.Windows;

namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        private readonly Subscriber<DateTime> subscriber;
        public MainWindow()
        {
            InitializeComponent();
            subscriber = new Subscriber<DateTime>(dummy);
        }

        private void dummy(object sender, DateChangedArgument<DateTime> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now;
            AddNoteWindow addNoteWindow = new AddNoteWindow(date);
            addNoteWindow.ShowDialog();
            subscriber.PublishData(new DateChangedArgument<DateTime>(date.Date));
        }

        private void SingleDayPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MonthWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void WeatherWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
