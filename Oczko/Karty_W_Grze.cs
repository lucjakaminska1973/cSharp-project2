using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Oczko
{
    

    public class Karty_W_Grze : Talia
    {
        public byte suma;
        public Karty karta = new Karty();
        protected byte index;
        protected List<byte> indexyWydane;
        protected static string dodacKarte;
        protected static byte punkty_Asa;
         public Karty[] taliaGracza = new Karty[IleKart];
        
        public Karty_W_Grze(byte ileKart) : base(IleKart)
        {
            DodacKarte = "T";
            indexyWydane = new List<byte>();
            suma = 0;
            
            
             taliaGracza= GetTalia;
            
        }
        //public Karty[] KartyGracza { get { return GetTalia; } }



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
                    throw new ArgumentException("ERROR");
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
                    throw new ArgumentException("ERROR");
                }
            }
        }

        public string Zapytaj()
        {
            Console.WriteLine("Chcesz dobrać kartę?");
            DodacKarte = Console.ReadLine();
            return DodacKarte;
        }
        public void Wypisz_Punkty(byte suma)
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
            for (byte i = 0; i < IleKart; i++)
            {
                Wypisz_Karte(IleKart,taliaGracza[i],i);
            }

            while (DodacKarte == "T" || DodacKarte == "t")
            {

                do
                {
                    Index = WylosujKarte();
                } while (indexyWydane.Contains(Index));

                indexyWydane.Add(index);
                if (IleKart == 52)
                {
                    if ((index <= 5 && index >= 0) || (index <= 18 && index >= 13)
                       || (index <= 31 && index >= 26) || (index <= 39 && index >= 32) || (index <= 52 && index >= 47))
                    {
                        Wypisz_Karte(IleKart, taliaGracza[index], Index);
                        byte v = byte.Parse(taliaGracza[Index].Numerek.ToString("D"));

                        if (v == 1)
                        {
                            v = Za_ile_As();
                        }
                        
                        suma += v;
                        Wypisz_Punkty(suma);
                        //return suma.Total;
                    }
                    else
                    {
                        Wypisz_Karte(IleKart, taliaGracza[index], Index);
                        suma += byte.Parse(taliaGracza[index].DodatkoweNumerki.ToString("D"));
                        //byte i = byte.Parse(taliaGracza[index].DodatkoweNumerki.ToString("D"));
                        Wypisz_Punkty(suma);
                    }
                }
                else
                {
                    Wypisz_Karte(IleKart, taliaGracza[index], Index);
                    byte v = byte.Parse(taliaGracza[Index].Numerek.ToString("D"));
                    suma += v;
                    Wypisz_Punkty(suma);
                }
                if (suma == 21)
                {
                    Console.WriteLine("OCZKO!!!");
                    dodacKarte = "n";
                }
                else
                {
                    Zapytaj();
                }
                
            }
            if (DodacKarte == "n" || DodacKarte == "N")
            {
                indexyWydane.Clear();
                Wypisz_Punkty(suma);
                return suma;
            }
            else
            {
                throw new ArgumentException("powtórz co mam zrobić");
            }



        }
        public string Czy_Dobrac_Komp()
        {
            int j = 0;
            for (byte i = 0; i < IleKart; i++)
            {

                byte n = byte.Parse(taliaGracza[Index].Numerek.ToString("D"));
                byte dn = byte.Parse(taliaGracza[index].DodatkoweNumerki.ToString("D"));
                byte sum = suma;
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
            DodacKarte = j > 3 ? "t" : "n";
            return DodacKarte;


        }
        public byte Punkty_Komputer()
        {

            do
            {
                do
                {
                    Index = WylosujKarte();
                } while (indexyWydane.Contains(index));

                indexyWydane.Add(Index);
                if (IleKart == 52)
                {
                    if ((index <= 5 && index >= 0) || (index <= 18 && index >= 13)
                        || (index <= 31 && index >= 26) || (index <= 39 && index >= 32) || (index <= 52 && index >= 47))
                    {
                        byte v = byte.Parse(taliaGracza[Index].Numerek.ToString("D"));
                        Wypisz_Karte(IleKart, taliaGracza[index], Index);

                        suma += v;
                        Wypisz_Punkty(suma);

                    }
                    else
                    {
                        Wypisz_Karte(IleKart, taliaGracza[index], Index);
                        suma += byte.Parse(taliaGracza[index].DodatkoweNumerki.ToString("D"));
                        Wypisz_Punkty(suma);
                    }
                }
                else
                {
                    byte v = byte.Parse(taliaGracza[Index].Numerek.ToString("D"));
                    Wypisz_Karte(IleKart, taliaGracza[index], Index);
                    Wypisz_Punkty(suma);
                }
                if (suma == 21)
                {
                    Console.WriteLine("OCZKO!!!");
                    dodacKarte = "n";
                }
                else
                {
                    Czy_Dobrac_Komp();
                }
                
            } while (DodacKarte == "t");

            if (DodacKarte == "n" || DodacKarte == "N")
            {
                indexyWydane.Clear();
                Wypisz_Punkty(suma);
                return suma;
            }
            else
            {
                throw new ArgumentException("powtórz co mam zrobić");
            }


        }

        public void Wypisz_Karte(byte ileKart, Karty karta, byte index)
        {
            if (ileKart == 52)
            {
                if ((index <= 5 && index >= 0) || (index <= 18 && index >= 13)
                    || (index <= 31 && index >= 26) || (index <= 39 && index >= 32) || (index <= 52 && index >= 47))
                {


                    Console.Write(taliaGracza[index].Numerek.ToString("f"));
                    Console.Write("  ");
                    Console.WriteLine(taliaGracza[index].Kolorek.ToString("f"));
                }
                else
                {
                    Console.Write(taliaGracza[index].DodatkoweNumerki.ToString("f"));
                    Console.Write("  ");

                    Console.WriteLine(taliaGracza[index].Kolorek.ToString("f"));
                }
            }
            else
            {
                Console.Write(value: taliaGracza[index].Numerek.ToString("f"));
                Console.Write("  ");
                Console.WriteLine(value: taliaGracza[index].Kolorek.ToString("f"));
            }
        }
        //public void Wypisz_Punkty(byte punkty)
        //{
        //    Console.WriteLine($"Suma zdobytych punktów {suma.Total} ");
        //}
    }
}
