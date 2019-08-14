using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Calendar.DataAccess;

namespace Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy SingleDayPage.xaml
    /// </summary>
    public partial class MonthWindow : UserControl
    {
        internal System.DateTime _DisplayStartDate;
        private int _DisplayMonth;
        private int _DisplayYear;
        private int iDaysInMonth;
        private int dayOfFirstDay;
        private CultureInfo _cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.LCID);
        private System.Globalization.Calendar sysCal;

        NotesDataAccess dataAccess = new NotesDataAccess();
        DateTime _date;
        public MonthWindow(DateTime date)
        {
            InitializeComponent();
            _cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.LCID);
            sysCal = _cultureInfo.Calendar;
            _DisplayMonth = _DisplayStartDate.Month;
            _DisplayYear = _DisplayStartDate.Year;
            iDaysInMonth = sysCal.GetDaysInMonth(_DisplayStartDate.Year, _DisplayStartDate.Month);
            _date = date;
            _DisplayStartDate = _date.AddDays(-1 * (_date.Day - 1));
            dayOfFirstDay = _DisplayStartDate.Day;

            Load();
        }

        public MonthWindow() : this(DateTime.Now)
        { }

        //private void Load()
        //{
        //    _DisplayMonth = _DisplayStartDate.Month;
        //    _DisplayYear = _DisplayStartDate.Year;
        //    sysCal = _cultureInfo.Calendar;
        //    iDaysInMonth = sysCal.GetDaysInMonth(_DisplayStartDate.Year, _DisplayStartDate.Month);

        //    NewStackPanel2.Children.Clear();

        //    int fDay = FirstDayOfTheMonth();



        //    for (int i = 0; i < 1; i++)
        //    {
        //        for (int j = 0; j < fDay - 1; j++)
        //        {
        //            TextBlock textBlock = new TextBlock();
        //            textBlock.Background = Brushes.White;

        //            Grid.SetRow(textBlock, 0);
        //            Grid.SetColumn(textBlock, j);
        //            NewStackPanel2.Children.Add(textBlock);
        //        }

        //        for (int j = fDay - 1; j < 7; j++)
        //        {
        //            var date = new DateTime(_DisplayYear, _DisplayMonth, dayOfFirstDay);
        //            SingleDayPage singleDayPage = new SingleDayPage(date);

        //            Grid.SetRow(singleDayPage, 0);
        //            Grid.SetColumn(singleDayPage, j);
        //            NewStackPanel2.Children.Add(singleDayPage);
        //            dayOfFirstDay++;
        //        }
        //    }
        //    for (int i = 1; i < 5; i++)
        //    {
        //        for (int j = 0; j < 7; j++)
        //        {
        //            var date = new DateTime(_DisplayYear, _DisplayMonth, dayOfFirstDay);

        //            SingleDayPage singleDayPage = new SingleDayPage(date);

        //            Grid.SetRow(singleDayPage, i);
        //            Grid.SetColumn(singleDayPage, j);
        //            NewStackPanel2.Children.Add(singleDayPage);

        //            if (dayOfFirstDay >= iDaysInMonth)
        //                return;

        //            dayOfFirstDay++;
        //        }
        //    }
        //}
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
        private int FirstDayOfTheMonth()
        {
            int iOffsetDays = Convert.ToInt32(System.Enum.ToObject(typeof(System.DayOfWeek), _DisplayStartDate.DayOfWeek));
            return iOffsetDays;
        }

    }
}
