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
            Player comp = new Player();
            Player home = new Player();
            home.PushCard(cd.GetTwoCards());
            comp.PushCard(cd.GetTwoCards());// komputer jako krupier - po dwie karty
            int pv = home.GetHandCardsValue();
            int cv = comp.GetHandCardsValue();

            Console.WriteLine("Karty gracza" + string.Join(' ', home.GetHandCardsList));
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
                    break;
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
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Karty komputera" + string.Join(' ', comp.GetHandCardsList));
            Console.WriteLine(comp.GetHandCardsValue());
            i = 2;
            int toGoal = 21 - cv;

            var newList = cd.GetTabCards.FindAll(x => x.Value < toGoal);
            if (newList.Count > 6)
            {
                linia = "t";

            }
            //foreach(var c in newList)
            //{
            //    Console.WriteLine(string.Join(' ', c));
            //    Console.WriteLine(newList.Count);
            //}
            newList.Clear();
            
            while (linia == "t")
            {
                comp.PushCard(cd.GetOneCard());
                Console.WriteLine(string.Join(' ', comp.GetHandCardsList[i]));
                Console.WriteLine(comp.GetHandCardsValue());
                if (comp.GetHandCardsValue() < 21)
                {
                     cv = comp.GetHandCardsValue();
                     toGoal = 21 - cv;

                     newList = cd.GetTabCards.FindAll(x => x.Value < toGoal);
                    if (newList.Count > 6)
                    {
                        linia = "t";
                    }
                    newList.Clear();
                }
                else if (comp.GetHandCardsValue() == 21)
                {
                    Console.WriteLine("Masz oczko!!!");
                    break;
                }
                else
                {
                    Console.WriteLine("Przegrana");
                    break;
                }
                
                if (linia != "t") break;
                i++;
            }
            if (cv>pv)
            {
                Console.WriteLine($"{home.Name} WIN");
            }
            else
            {
                Console.WriteLine("COMP WIN");
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
