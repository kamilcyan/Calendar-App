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


           
                    word.wezHaslo();
                    word.rysujHaslo();
                    //word.PodajLitere();
                    word.sprawdz(word.literka, word.haslo);
                    word.sprawdzGameOver();
   
    Console.ReadKey();
        }
    }
}
