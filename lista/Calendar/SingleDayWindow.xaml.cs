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
using System.Data.Entity;

namespace Calendar
{
    public partial class SingleDayWindow : Window
    {
        public SingleDayWindow()
        {
            InitializeComponent();
            SingleDayWindowFormating();
        }

        private void SingleDayWindowFormating()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Name = "NewStackPanel";

            TextBlock textBlock1 = new TextBlock();
            textBlock1.Name = "DateTextBlock";
            textBlock1.FontSize = 50;
            Thickness m = textBlock1.Margin;
            m.Bottom = 20;
            textBlock1.Margin = m;
            textBlock1.Text = DateTime.Now.Day.ToString();
            //NewStackPanel.Children.Add(textBlock1);
            NewStackPanel.RegisterName(textBlock1.Name, textBlock1);

            TextBlock textBlock2 = new TextBlock();
            textBlock2.Name = "ListOfNotes";
            textBlock2.Text = "List of notes for today:";
            Thickness n = textBlock2.Margin;
            n.Bottom = 20;
            textBlock2.Margin = n;
            //NewStackPanel.Children.Add(textBlock2);
            NewStackPanel.RegisterName(textBlock2.Name, textBlock2);

            TextBlock textBlock3 = new TextBlock();
            textBlock3.Name = "ShowNotes";
            CalendarDbContext db = new CalendarDbContext();

            Note note = new Note();
            for (int i = 3; i <note.Id; i++)
            {
                note = db.Notes.Find(i);
                
            }
            textBlock3.Text = note.Body;

            //NewStackPanel.Children.Add(textBlock3);
            NewStackPanel.RegisterName(textBlock3.Name, textBlock3);


            Button button1 = new Button();
            button1.Name = "AddNoteButton";
            button1.Content = "Add note";
            button1.VerticalAlignment = VerticalAlignment.Center;
            button1.HorizontalAlignment = HorizontalAlignment.Left;
            button1.Height = 50;
            button1.Width = 70;
            button1.Click += new RoutedEventHandler(AddNoteButton_Click);
            //NewStackPanel.Children.Add(button1);
            NewStackPanel.RegisterName(button1.Name, button1);
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            AddNoteWindow addNoteWindow = new AddNoteWindow();
            addNoteWindow.ShowDialog();
            
        }
    }
}
