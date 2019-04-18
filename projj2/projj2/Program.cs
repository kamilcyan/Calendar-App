using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projj2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Dzialanie dzial = new Dzialanie();
            dzial.podaj();
            dzial.pokaz(dzial.wynik);

            Console.ReadKey();
        }
        
}
   
}
