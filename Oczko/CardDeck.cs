using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Oczko
{
    public class CardDeck 
    {
        public const int SIZE = 52;

        protected List<Card> tabCards;
      
        public CardDeck()
        {
            tabCards = new List<Card>(SIZE);
            setUpDeck();
        }

        public List<Card> GetTabCards => tabCards;
        //{
        //    get 
        //    {
        //        return tabCards;
        //    } 
        //}

        public Card GetCard(int index) => tabCards[index];

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
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < tabCards.Count; j++)
                {                
                    int index2 = rand.Next(tabCards.Count);
                    temp = tabCards[j];
                    tabCards[j] = tabCards[index2];
                    tabCards[index2] = temp;
                }
            }
        }
    
        public Card GetOneCard()
        {
            Card c = tabCards[0];
            tabCards.RemoveAt(0);
            return c;
        }

        public List<Card> GetTwoCards()
        {
            var tempList = new List<Card>(2);
            tempList.Add(GetOneCard());
            tempList.Add(GetOneCard());
            return tempList;
        }
    }

}
