using System;
using System.Collections.Generic;
using System.Text;

namespace Oczko
{
    public class Rozgrywka : Karty_W_Grze
    {
        public List<byte> wyniki;
        
        public int IleRund { get; set; }
        public byte gracz;
        public byte komp;
        public Rozgrywka(byte IleKart) : base(IleKart)
        {
            kartyGracza = GetTalia;
            //ileKart = Ile_Kart();
            wyniki = new List<byte>();
            gracz = 0;
            komp = 0;
        }


        public List<byte> Zagraj()
        {
            Talia_Kreator();
            Ile_Rund();
            for (int i = 0; i < IleRund; i++)
            {
                Punkty_Gracza();
                wyniki.Add(suma);
                Punkty_Komputer();
                wyniki.Add(suma);
            }

            return wyniki;
        
        }
        public void Wynik_Koncowy()
        {
            
            
            for (int i = 0; i < wyniki.Count; i += 2)
            {
                if (wyniki[i] > wyniki[i + 1])
                {
                    gracz += 1;
                }
                else
                {
                    komp += 1;
                }
            }
            if (gracz > komp)
            {
                Console.WriteLine("GRATULACJE 4U!!!");
            }
            else
            {
                Console.WriteLine("KOMPUTER BYŁ LEPSZY:(");
            }

            
            


        }
        public int Ile_Rund()
        {
            Console.WriteLine("Ile rund chcesz zagrać?");
            IleRund = int.Parse(Console.ReadLine());
            return IleRund;
        }
        
        





    }
}
