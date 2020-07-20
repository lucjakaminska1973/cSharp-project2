using System;
using System.Collections.Generic;
using Oczko;
using System.Text;

namespace Gra_Oczko
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            
            Console.WriteLine(" GRAMY W OCZKO !!!");
            CardDeck cd = new CardDeck();

            Player home = new Player();
            home.PushCard(cd.GetTwoCards());
            Console.WriteLine(string.Join(' ', home.GetHandCardsList));
            Console.WriteLine(home.GetHandCardsValue());
            int i = 2;
            Console.WriteLine("Dodać karte t/n");
            string linia = Console.ReadLine();
            while (linia == "t")
            {
                home.PushCard(cd.GetOneCard());
                Console.WriteLine(string.Join(' ', home.GetHandCardsList[i]));
                Console.WriteLine(home.GetHandCardsValue());
                if (home.GetHandCardsValue() < 21)
                {
                    Console.WriteLine("Dodać karte t/n");
                }
                else if (home.GetHandCardsValue() == 21)
                { 
                    Console.WriteLine("Masz oczko!!!");
                }
                else
                {
                    Console.WriteLine("Przegrana");
                    break;
                }
                linia = Console.ReadLine();
                if (linia != "t") break;
                i++;
            } 

            //for (int i = 0; i < 52; i++)
            //{
            //    Card card = cd.GetCard(i);
            //    Console.WriteLine(card.ToString());
            //}

                //Console.ReadLine();
        }
    }
}
