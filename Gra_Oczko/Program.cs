using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Oczko;

namespace Gra_Oczko
{
    class Program
    {
        static void Main(string[] args)
        {
            string linia = " ";  
            
            Console.WriteLine(" GRAMY W OCZKO !!!");
            while (linia != "" && linia != null)
            {
                var x = Talia.Ile_Kart();
            
             Rozgrywka r = new Rozgrywka(x);
            
                
                r.Zagraj();
                r.Wynik_Koncowy();
                //Console.WriteLine("\n Jeszcze raz? \n ENTER kończy grę:(");
                //linia = Console.ReadLine();

                

            }
            Console.ReadLine();
        }
    }
}
