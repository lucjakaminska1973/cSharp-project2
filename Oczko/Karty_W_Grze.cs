using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Oczko
{
    public struct Punkty
    {
        public byte Total { get; set; }
        public byte Punkty_Karty { get; set; }
    }

    public class Karty_W_Grze : Talia
    {
        public Punkty suma;
        public Karty[] kartyGracza;
        protected byte index;
        protected List<byte> indexyWydane;
        public static string dodacKarte;
        protected static byte punkty_Asa;

        public Karty_W_Grze(byte IleKart) : base(IleKart)
        {
            dodacKarte = "T";
            indexyWydane = new List<byte>();
            suma = new Punkty();
            this.kartyGracza = GetTalia;

            // punkty_Karty = new Punkty();
        }



        protected static byte Punkty_Asa
        {
            get
            {
                return punkty_Asa;
            }
            set
            {
                if (value == 1 || value == 11)
                {
                    punkty_Asa = value;
                }
                else
                {
                    throw new ArgumentException("Możesz wybrać 1 lub 11");
                }
            }

        }


        private byte Index
        {
            get
            {
                return index;
            }
            set
            {
                if (value >= 0 && value < IleKart)
                {
                    index = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public static string DodacKarte
        {
            get => dodacKarte;

            set
            {
                if (value == "T" || value == "t" || value == "n" || value == "N")
                {
                   dodacKarte = value;
                }
                else
                {
                    throw new ArgumentException("Zły wybór");
                }
            }
        }

        public string Zapytaj()
        {
            Console.WriteLine("Chcesz dobrać kartę?");
            dodacKarte = Console.ReadLine();
            return dodacKarte;
        }
        public void Wypisz_Punkty()
        {
            Console.WriteLine($"masz {suma} punktów");
        }


        public byte WylosujKarte()
        {
            Random indexKarty = new Random();
            index = (byte)indexKarty.Next(IleKart);

            return index;

        }
        public byte Za_ile_As()
        {
            Console.WriteLine("Masz Asa. Podaj ile chcesz dodać punktów ( 1 lub 11)");
            punkty_Asa = byte.Parse(Console.ReadLine());

            return punkty_Asa;
        }



        public byte Punkty_Gracza()
        {

            while (dodacKarte == "T" || dodacKarte == "t")
            {

                do
                {
                    index = WylosujKarte();
                } while (indexyWydane.Contains(index));

                indexyWydane.Add(index);

                if ((index <= 5 && index >= 0) || (index <= 18 && index >= 13)
                    || (index <= 31 && index >= 26) || (index <= 39 && index >= 32) || (index <= 52 && index >= 47))
                {
                    byte v = (byte)kartyGracza[index].Numerek;
                    Wypisz_Karte(IleKart, kartyGracza[index], index);
                    if (v == 1)
                    {
                        v = Za_ile_As();
                    }
                    suma.Total += v;
                    Wypisz_Punkty(suma);
                    //return suma.Total;
                }
                else
                {
                    Wypisz_Karte(IleKart, kartyGracza[index], index);
                    suma.Total += (byte)kartyGracza[index].DodatkoweNumerki;
                    Wypisz_Punkty(suma);
                }
                Zapytaj();
            }
            if (dodacKarte == "n" || dodacKarte == "N")
            {
                indexyWydane.Clear();
                Wypisz_Punkty();
                return suma.Total;
            }
            else
            {
                throw new ArgumentException("powtórz co mam zrobić");
            }



        }
        public string Czy_Dobrac_Komp(byte x)
        {
            int j = 0;
            for (byte i = 0; i < IleKart; i++)
            {

                byte n = (byte)kartyGracza[i].Numerek;
                byte dn = (byte)kartyGracza[i].DodatkoweNumerki;
                byte sum = (byte)suma.Total;
                bool c = indexyWydane.Contains(i);
                if (c == false)
                {
                    if (IleKart == 24)
                    {
                        if (n < 21 - sum) j++;



                    }
                    else
                    {
                        if (n < 21 - sum) j++;
                        if (dn < 21 - sum) j++;

                    }
                }

            }
            dodacKarte = j > 3 ? "t" : "n";
            return dodacKarte;


        }
        public byte Punkty_Komputer()
        {

            do
            {
                do
                {
                    index = WylosujKarte();
                } while (indexyWydane.Contains(index));

                indexyWydane.Add(index);

                if ((index <= 5 && index >= 0) || (index <= 18 && index >= 13)
                    || (index <= 31 && index >= 26) || (index <= 39 && index >= 32) || (index <= 52 && index >= 47))
                {
                    byte v = (byte)kartyGracza[index].Numerek;
                    Wypisz_Karte(IleKart, kartyGracza[index], index);

                    suma.Total += v;
                    Wypisz_Punkty(suma);

                }
                else
                {
                    Wypisz_Karte(IleKart, kartyGracza[index], index);
                    suma.Total += (byte)kartyGracza[index].DodatkoweNumerki;
                    Wypisz_Punkty(suma);
                }
                Czy_Dobrac_Komp(suma.Total);
            } while (DodacKarte == "t");

            if (dodacKarte == "n" || dodacKarte == "N")
            {
                indexyWydane.Clear();
                Wypisz_Punkty();
                return suma.Total;
            }
            else
            {
                throw new ArgumentException("powtórz co mam zrobić");
            }


        }
        public void Wypisz_Karte(byte ileKart, Karty karty, byte index)
        {
            if (ileKart ==52)
            {
                if ((index <= 5 && index >= 0) || (index <= 18 && index >= 13)
                    || (index <= 31 && index >= 26) || (index <= 39 && index >= 32) || (index <= 52 && index >= 47))
                {


                    Console.Write(karty.Numerek);
                    Console.Write("  ");
                    Console.WriteLine(karty.Kolorek);
                }
                else
                {
                    Console.Write(karty.DodatkoweNumerki);
                    Console.Write("  ");

                    Console.WriteLine(karty.Kolorek);
                }
            }
            else
            {
                Console.Write(value: karty.Numerek);
                Console.Write("  ");
                Console.WriteLine(value: karty.Kolorek);
            }
        }
        public void Wypisz_Punkty(Punkty punkty) => Console.WriteLine($"Suma zdobytych punktów {suma.Total} ");



    }
}
