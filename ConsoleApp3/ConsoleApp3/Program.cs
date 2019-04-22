using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, temp;
            Console.WriteLine("Podaj pierwszy numer");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj drugier");
            num2= int.Parse(Console.ReadLine());

            temp = num1;
            num1= num2;
            num2 = temp;

            Console.WriteLine("zamieniona kolejność to: " + num1 + " " + num2);

            Console.ReadKey();
        }
    }
}
