using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, r;
            int sum = 0;

            Console.WriteLine("Podaj liczbę");
            num=int.Parse(Console.ReadLine());

            while(num!=0)
            {
                r=num%10;
                num = num / 10;
                sum = sum + r;
            }
            Console.WriteLine("suma: "+sum);
            Console.ReadLine();
        }
    }
}
