using System;
using System.Collections.Generic;
using System.Text;

namespace Oczko
{
    public class Talia : Karty
    {
        public byte ileKart;
        public static byte IleKart { get; private set; }
        //{
        //    get
        //    {
        //        return ileKart;
        //    }

        //    set
        //    {
        //        if (value == 52 || value == 24)
        //        {
        //            ileKart = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("ERROR");
        //        }

        //    }
        //}

        protected readonly Karty[] wybrana_Talia;
        public Karty[] GetTalia { get { return wybrana_Talia; } }

        public Talia(byte IleKart)
        {
            wybrana_Talia = new Karty[IleKart];
        }

        public Talia() { }





        public static byte Ile_Kart()
        {
            Console.WriteLine("Wybierz talię : 24 lub 52 karty");
            IleKart = byte.Parse(Console.ReadLine());
            if (IleKart == 52 || IleKart == 24)
            {
                return IleKart;
            }
            else
            {
                throw new ArgumentException();
            }

        }


        public void Talia_Kreator()
        {
           // IleKart = Ile_Kart();
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
