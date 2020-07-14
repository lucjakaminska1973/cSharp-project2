using System;
using System.Collections.Generic;
using System.Text;

namespace Oczko
{
    public class Talia : Karty
    {

        public static byte IleKart
        {
            get
            {
                return IleKart;
            }

            set
            {
                if (value == 52 || value == 24)
                {
                    IleKart = value;
                }
                else
                {
                    throw new ArgumentException("Możesz wybrać 52 lub 24");
                }

            }
        }

        private readonly Karty[] wybrana_Talia;


        public Talia(byte IleKart) => wybrana_Talia = new Karty[IleKart];

        public Talia() { }
        
        

        public Karty[] GetTalia { get { return wybrana_Talia; } }

        public static byte Ile_Kart()
        {
            Console.WriteLine("Wybierz talię : 24 lub 52 karty");
             IleKart = byte.Parse(Console.ReadLine());
            return IleKart;
        }


        public void Talia_Kreator(byte ileKart)
        {
            
            foreach (Kolor k in Enum.GetValues(typeof(Kolor)))
            {
                int i = 0;
                foreach (Numer n in Enum.GetValues(typeof(Numer)))
                {
                    var karty = new Karty { Kolorek = k, Numerek = n };
                    wybrana_Talia[i] = karty;
                    i++;
                }
                if (ileKart == 52)
                {
                    foreach (DodatkoweNumery nd in Enum.GetValues(typeof(DodatkoweNumery)))
                    {
                        var karty = new Karty { Kolorek = k, DodatkoweNumerki = nd };
                        wybrana_Talia[i] = karty;
                        i++;
                    }

                }

            }

        }

    }
}
