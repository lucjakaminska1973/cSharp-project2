using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            CardDeck cd = new CardDeck();
            
            for (int i = 0; i < 52; i++)
            {
                cd.GetTabCards();
            

                //Console.WriteLine(card.ToString());
            }

                

            
            Console.ReadLine();
        }
    }
}
