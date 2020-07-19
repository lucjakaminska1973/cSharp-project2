using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Oczko
{



    
    class Card
    {
        public enum CardColor// Jeżeli wyrzucę poza klasę to nie są dostępne
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

        public  CardColor Color { get; set; }
        public  CardName Name { get; set; }// muszę dać set bo potem nie daje mi utwożyc talii -CardDeck.setUpDeck()
        public int Value { get; set; }
        

        public Card(CardColor color, CardName name)
        {
            Color = color;
            Name = name;
            Value = GetValue(Name);

        }
        public Card card = new Card( Color, Name);// tu  podkreśla pola i woła 
        //ze utworzenie karty wymaga odwołania do pola statycznego. nie wiem co z tym zrobic, 
        //bo na staticu nie dje zapisac tablicy talia kartami
        // a jeżeli przypiszę static nie mogę użyć jako pola w konst
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
            return DisplayCard(Color);
        }

        public string DisplayCard(CardColor cc)
        {
            Console.ForegroundColor = ConsoleColor.White;
             char charcardColor = ' ';
            //string cc = Enum.GetName(typeof(CardColor),card);
            // nie wiem 
            switch (cc)
            {
                case CardColor.HEARTS:
                    charcardColor = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.CardColor.DIAMONDS:
                    charcardColor = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.CardColor.CLUBS:
                    charcardColor = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Card.CardColor.SPADES:
                    charcardColor = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                    
            }
            return $"{Name}{charcardColor}";
           

           

        }
       
    }
}

