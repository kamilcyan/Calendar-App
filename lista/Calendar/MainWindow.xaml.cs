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

namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            textBlockFormatting();
            startButtonFormatting();

        }

        private void startButtonFormatting()
        {
            Button startButton = new Button();
            startButton.Name = "startButton";
            startButton.Click += new RoutedEventHandler(StartButton_Click);
            startButton.Content = "Start";
            startButton.Height = 50;
            startButton.Width = 100;
            NewStackPanel.Children.Add(startButton);
        }

        private void textBlockFormatting()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "<Temporary>";
            textBlock.FontSize = 20;
            textBlock.Name = "newTextBlock";
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.Height = 50;
            textBlock.Width = 100;
            NewStackPanel.Children.Add(textBlock);
            NewStackPanel.RegisterName(textBlock.Name, textBlock);
           
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
            SingleDayWindow singleDayWindow = new SingleDayWindow();
            singleDayWindow.Show();
        }
    }
}
