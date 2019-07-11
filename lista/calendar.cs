using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show
{
    public class ShowMain
    {
        public static void display(int day, int year, int month)
        {

            

            

            Console.WriteLine("\nPon\tWto\tSro\tCzw\tPia\tSob\tNie\n");

            for (int i = 1; i < (DateTime.DaysInMonth(year, month)) + 1; i++)
            {


                if (i % 7 == 0)
                {
                    Console.WriteLine(i + "\n");
                }
                else
                {
                    Console.Write(i + "\t");
                }
                if (i == day - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                    Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("\n");

            
        }
        /*
        public string firstDayOfMonth()
        {
            int dayNow = DateTime.Now.Day;
            int firstDay;

            firstDay = dayNow - dayNow % 7;
        }*/

        public static void Menu()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.Write("-\t");
            }

            Console.WriteLine("\nMENU\n\nMenu Options:\n1.\tPrevious month\n2.\tNext month\n3.\tNotes");

            for (int i = 0; i < 7; i++)
            {
                Console.Write("-\t");
            }
            Console.Write("\n");
            
        }

        public static void MenuOptions()
        {
            int choose;

            int.TryParse(Console.ReadLine(), out choose);

            switch (choose)
                {
                    case 1:
                        Console.Clear();
                        display(1, 2019, DateTime.Now.Month-1);
                        break;
                    case 2:
                        //nextMonth();
                        break;
                    case 3:
                        //notes();
                        break;
                    default:
                        break;
                }
            
        }
    }
}
