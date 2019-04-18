using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Slowo word = new Slowo();


           //// for(int i=0; i<10; i++)
           // {
           //    // if (word.licznikTrafionych < word.haslo.Length)
           //     {
                    word.wezHaslo();
                    word.rysujHaslo();
                    //word.PodajLitere();
                    word.sprawdz(word.literka, word.haslo);
                    word.sprawdzGameOver();
    //    }
    //}

    Console.ReadKey();
        }
    }
}
