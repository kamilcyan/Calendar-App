using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Calendar.DataAccess;
using Calendar.EventHandler;

namespace Calendar
{
    public partial class MonthsWindow : UserControl, IDisposable
    {
        Subscriber<int> subscriber = new Subscriber<int>( dummy);

        private static void dummy(object sender, DateChangedArgument<int> e)
        {
        }

        public MonthsWindow()
        {
            InitializeComponent();

            for(int i=1; i<=12; i++)
            {
                var date = new DateTime(1, i, 1);
                TextBlock b = new TextBlock();
                b.Text = date.ToString("MMMM");
                b.FontSize = 20;
                int icopy = i;
                b.MouseLeftButtonDown += (x, y) => UpdateMonth(icopy);
                if(i.Equals(DateTime.Today.Month))
                {
                    b.Background = new SolidColorBrush(Color.FromRgb(200,0,0));
                }
                Grid.SetRow(b, i-1 );
                NewStackPanel2.Children.Add(b);
            }
        }

        private void UpdateMonth(int i)
        {
            subscriber.PublishData(new DateChangedArgument<int>(i));
        }

        public void Dispose()
        {
            subscriber.Dispose();
        }
    }
}