using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Oczko
{
    class CardDeck :Card
    {
        
        protected Card[] tabCards;
      
        public CardDeck()
        {

            tabCards = new Card[52];
            
        }
        public Card[]GetTabCards{ get {return tabCards;} }
            


        
        
        public void setUpDeck()
        {

            int i = 0;
            foreach (Card.CardColor c in Enum.GetValues(typeof(Card.CardColor)))
            {
                foreach (Card.CardName v in Enum.GetValues(typeof(Card.CardName)))
                {
                    Card card = new Card { Color = c, Name = v };
                    tabCards[i] = card;
                    i++;
                }
            }
        }
      }

}
