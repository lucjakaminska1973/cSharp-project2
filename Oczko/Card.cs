using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Oczko
{


    public enum CardColor
    {
        HEARTS,
        SPADES,
        DIAMONDS,
        CLUBS
    }

    public enum CardName
    {
        TWO, THREE, FOUR, FIVE, SIX, SEVEN,
        EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
    }

    public class Card
    {
        

        public  CardColor Color { get; set; }
        public  CardName Name { get; set; }// muszę dać set bo potem nie daje mi utwożyc talii -CardDeck.setUpDeck()
        public int Value { get; set; }
        

        public Card(CardColor color, CardName name)
        {
            Color = color;
            Name = name;
            Value = GetValue(Name);

        }
       
        public int GetValue(CardName cn)
        {
            int value=0;
            switch(cn)
            {
                case CardName.ACE:
                    value = 1;
                    break;
                case CardName.TWO:
                case CardName.JACK:
                    value = 2;
                    break;
                case CardName.THREE:
                case CardName.QUEEN:
                    value = 3;
                    break;
                case CardName.FOUR:
                case CardName.KING:
                    value = 4;
                    break;
                case CardName.FIVE:
                    value = 5;
                    break;

                case CardName.SEVEN:
                    value = 7;
                    break;
                case CardName.EIGHT:
                    value = 8;
                    break;
                case CardName.NINE:
                    value = 9;
                    break;
                case CardName.TEN:
                    value = 10;
                    break;

            }
            return value;
        }

        public override string ToString()
        {

            return $"{Name}{ DisplayCard(Color)}";
        }

        public string DisplayCard(CardColor cc)
        {
            
             char charcardColor = ' ';
            
            switch (cc)
            {
                case CardColor.HEARTS:
                    charcardColor = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                   
                    break;
                case CardColor.DIAMONDS:
                    charcardColor = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    
                    break;
                case CardColor.CLUBS:
                    charcardColor = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                   
                    break;
                case CardColor.SPADES:
                    charcardColor = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    
                    break;
                    
            }
            return $"{charcardColor}";
           

           

        }
       
    }
}

