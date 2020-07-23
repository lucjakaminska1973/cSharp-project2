using System;
using System.Collections.Generic;
using System.Text;

namespace Oczko
{
    public class Player
    {
        public string Name { get; set; } = "anonim";

        private List<Card> handCards = new List<Card>();
        public IReadOnlyList<Card> GetHandCardsList => handCards.AsReadOnly();
        //private int toGoal { get; private set; }

        public void PushCard( Card card)
        {
            handCards.Add(card);
        }

        public void PushCard( List<Card> list )
        {
            foreach(var card in list)
            {
                handCards.Add(card);
            }
        }

        public int GetHandCardsValue()
        {
            if (handCards.Count == 0)
                return 0;
            int sum = 0;
            foreach( var card in handCards )
            {
                sum += card.Value;
            }

            return sum;
        }

        
    }
    
}
