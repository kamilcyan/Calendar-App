using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projj2
{
    class Dzialanie
    {
        public int liczba1;
        public int liczba2;
        public int wynik;
        public char znak;

        public void podaj()
        {
            Console.WriteLine("Podaj 1 liczbe");
            liczba1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj 2 liczbe");
            liczba2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj znak");
            znak = Convert.ToChar(Console.ReadLine());

            switch (znak)
            {
                case '+':
                    dodaj(liczba1, liczba2);
                    break;
                case '-':
                    odejmij(liczba1, liczba2);
                    break;
                case '*':
                    pomnoz(liczba1, liczba2);
                    break;
                case '/':
                    podziel(liczba1, liczba2);
                    break;
                

            }

        }
        public int dodaj(int liczba1, int liczba2)
        {
            wynik = liczba1 + liczba2;
            return wynik;
        }
        public int odejmij(int liczba1, int liczba2)
        {
            wynik = liczba1 - liczba2;
            return wynik;
        }
        public int pomnoz(int liczba1, int liczba2)
        {
            wynik = liczba1 * liczba2;
            return wynik;
        }
        public double podziel(int liczba1, int liczba2)
        {
            if (liczba2 != 0)
                wynik = liczba1 / liczba2;
            else
                Console.WriteLine("Blad");
            return wynik;
        }
        public void pokaz(int wynik)
        {
            Console.WriteLine("Wynik " + wynik);
           
        }
    }
}
