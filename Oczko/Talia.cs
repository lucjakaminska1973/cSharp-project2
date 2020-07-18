using System;
using System.Collections.Generic;
using System.Text;

namespace Oczko
{
    public class Talia : Karty
    {
        public byte ileKart;
        protected Array kolorvalues = Enum.GetValues(typeof(Kolor));
        protected Array numervalues = Enum.GetValues(typeof(Numer));
        protected Array dnumervalues = Enum.GetValues(typeof(DodatkoweNumery));
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


        public Karty[] Talia_Kreator()
        {
            //Array kolorvalues = Enum.GetValues(typeof(Kolor));
            //Array numervalues = Enum.GetValues(typeof(Numer));
            //Array dnumervalues = Enum.GetValues(typeof(DodatkoweNumery));
            int ind = 0;

            for (int i = 0; i < kolorvalues.Length; i++)
            {
                
                int j;
                Kolor k = (Kolor)kolorvalues.GetValue(i);
                for ( j = 0; j < numervalues.Length; j++)
                {
                    Numer n = (Numer)numervalues.GetValue(j);
                    var karty = new Karty { Kolorek = k, Numerek = n };
                    wybrana_Talia[ind] = karty;
                    ind++;
                }
                if (IleKart == 52)
                {
                    for (int jj = 0; jj < dnumervalues.Length; jj++)
                    {
                        DodatkoweNumery dn = (DodatkoweNumery)dnumervalues.GetValue(jj);
                        var karty = new Karty { Kolorek = k, DodatkoweNumerki = dn };
                        wybrana_Talia[ind] = karty;
                        ind++;
                    }

                }

            }
            return wybrana_Talia;
        }

    }


}
