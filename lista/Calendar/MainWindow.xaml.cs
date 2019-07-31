﻿using System;
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
        }

        private void textBlockFormatting()
        {
            var counter = 1;
            for (int i=0; i<5; i++)
            {
                for(int j=0; j<7; j++)
                {
                    List<Note> notes;
                    var date = new DateTime(2019, 07, counter);
                    if (DateTime.Now.Month == 2 && counter > 29) counter = 29;
                    else
                        if (counter < 31) counter = counter + 1;
                    else counter = 30;
                    
                    using (CalendarDbContext context = new CalendarDbContext())
                    {
                        var tomorrow = date.AddDays(1);
                        notes = context.Notes.Where(x => x.DateOfPosting > date && x.DateOfPosting < tomorrow).ToList();
                    }
                    SingleDayWindow singleDayWindow = new SingleDayWindow(notes, date);
                    Grid.SetRow(singleDayWindow, i);
                    Grid.SetColumn(singleDayWindow, j);
                    NewStackPanel2.Children.Add(singleDayWindow);
                }
            }


        }

        private void firstDayOfMonth()
        {
            DateTime now = DateTime.Now;
            DateTime firstDay = new DateTime(now.Year, now.Month, 1);
            string dayOfFirstDay = firstDay.DayOfWeek.ToString("dddd");
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
