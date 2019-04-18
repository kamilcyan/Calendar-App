using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projj
{
    class Program
    {
        static void Main(string[] args)
        {
            int wynik=0;
            char znak;
            Console.WriteLine("Podaj liczbe 1:");
            int liczba1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj liczbe 2:");
            int liczba2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj dzialanie:/n + - * /");
            znak = Convert.ToChar(Console.ReadLine());

            

            switch (znak)
            {
                case '+':
                    wynik = liczba1 + liczba2;
                    break;

                case '-':
                    wynik = liczba1 - liczba2;
                    break;

                case '*':
                    wynik = liczba1 * liczba2;
                    break;

                case '/':
                    if (liczba2 != 0)
                    {
                        wynik = liczba1 / liczba2;
                    }
                    else
                    {
                        Console.WriteLine("Nie mozna wykonac!");
                    }
                    break;

                default:
                    Console.WriteLine("Blad");
                    break;              
            }
            Console.WriteLine("Wynik to:" );
            Console.WriteLine(wynik);

            Console.ReadKey();
        }
    }
}
