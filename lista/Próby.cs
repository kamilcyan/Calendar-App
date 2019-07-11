using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace próby
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNow = DateTime.Now.Day;

            int findingIndeks()
            {
                int indeksDnia;
                int modOfDay = dayNow % 7;

                string dayNowName = DateTime.Now.DayOfWeek.ToString();

                string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

                for(int i = 0; i<7; i++)
                {
                    if(daysOfWeek[i] == dayNowName)
                    {
                        indeksDnia = i;
                        return indeksDnia+1;
                    }
                }
                return 0;
                
            }

         

            string dayName = DateTime.Now.DayOfWeek.ToString();


            Console.WriteLine(dayNow + dayName + firstDayOfMonth());

            Console.ReadKey();
        }
    }
}
// 1. dzisiejsza data
// 2. jaki dziś dzień
// 3. obliczyć modulo z 7
// od dzisiejszego dnia (nazwy) odjąć modulo