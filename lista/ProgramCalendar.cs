using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Show;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMain show = new ShowMain();

            Console.WriteLine("Today is:\n" + DateTime.Now + "\n");

            for (int i = 0; i < 7; i++)
            {
                Console.Write("-\t");
            }

            int day = DateTime.Now.Day;

            int year = DateTime.Now.Year;

            int month = DateTime.Now.Month;

            ShowMain.display(day, year, month);

            ShowMain.Menu();


            ShowMain.MenuOptions();

            Console.ReadKey();
        }

        
    }
}
