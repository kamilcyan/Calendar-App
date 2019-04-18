using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Slowo
    {
        public string haslo="rower";
        public char literka;
        public int licznikTrafionych = 0;

        public string wezHaslo()
        {
            haslo = "rower";
            return haslo;
        }

        public void rysujHaslo()
        {
            for(int i=0; i<haslo.Length; i++)
            {
                Console.Write("_ ");
            }
        }
        
        //public char PodajLitere()
        //{
        //    Console.WriteLine("\nPodaj literke");
        //    literka = Convert.ToChar(Console.ReadLine());
            
        //    return literka;
        //}

        public void sprawdz(char literka, string haslo)
        {
            while (licznikTrafionych < haslo.Length)
            {
                Console.WriteLine("\nPodaj literke");
                literka = Convert.ToChar(Console.ReadLine());
                for (int i = 0; i < haslo.Length; i++)
                {
                    if (literka == haslo[i])
                    {
                        Console.Write(literka);
                        licznikTrafionych++;
                    }
                    else 
                        Console.Write("_ ");
                }
                
                
            }
            sprawdzGameOver();
        }
        public void sprawdzGameOver()
        {
            if (licznikTrafionych == haslo.Length)
                gameOver();
            else
                sprawdz(literka, haslo);
        }
        public void gameOver()
        {
            Console.WriteLine("Gratuluje");
        }
        
    }
}
