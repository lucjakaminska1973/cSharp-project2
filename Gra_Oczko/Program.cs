using System;
using System.Collections.Generic;
using Oczko;

namespace Gra_Oczko
{
    class Program
    {
        static void Main(string[] args)
        {
            string linia = " ";  
            
            Console.WriteLine(" GRAMY W OCZKO !!!");

            Rozgrywka r = new Rozgrywka(Talia.Ile_Kart());
            
            while (linia != "" && linia != null)
            {
                r.Zagraj();
                Console.WriteLine("\n Jeszcze raz? \n ENTER kończy grę:(");
                linia = Console.ReadLine();
            }
            r.Wynik_Koncowy();


            Console.ReadLine();
        }
    }
}
