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
            byte x = Talia.Ile_Kart();
            //Talia t = new Talia(x);
            //t.Talia_Kreator(x);
            Rozgrywka r = new Rozgrywka(x);
            
            while (linia != "" && linia != null)
            
                r.Zagraj();
                Console.WriteLine("\n Jeszcze raz? \n ENTER kończy grę:(");
                linia = Console.ReadLine();
           
            r.Wynik_Koncowy();
            r.ToString();

            Console.ReadLine();
        }
    }
}
