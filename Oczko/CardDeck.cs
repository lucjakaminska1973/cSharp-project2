using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Oczko
{
    public class CardDeck 
    {
        
        protected List<Card> tabCards;
      
        public CardDeck()
        {

            tabCards = new List<Card>(52);
            setUpDeck();
        }
        public List<Card>GetTabCards{ get {return tabCards;} }

        public List<Card>GetTabCard(int index)
        {
            return tabCards[index];
        }




        private void setUpDeck()
        {

            int i = 0;
            foreach (CardColor c in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardName v in Enum.GetValues(typeof(CardName)))
                {
                    Card card = new Card(c, v);
                    tabCards.Add(card);
                    i++;
                }
            }
            ShuffleCards();
        }
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;

            
            for (int i= 0; i< 100; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                   
                    int index2 = rand.Next(13);
                    temp = tabCards[j];
                    tabCards[j] = tabCards[index2];
                    tabCards[index2] = temp;
                }
            }
        }
    }

}
