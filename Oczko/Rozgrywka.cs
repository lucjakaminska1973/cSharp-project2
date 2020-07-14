using System;
using System.Collections.Generic;
using System.Text;

namespace Oczko
{
    public class Rozgrywka : Karty_W_Grze
    {
        public List<byte> wyniki;
        public byte[] wynikKoncowy = new byte[2];
        public Rozgrywka(byte IleKart) : base(IleKart)
        {
            kartyGracza = GetTalia;
            IleKart = Ile_Kart();
            wyniki = new List<byte>();
        }

        public List<byte> Zagraj()
        {
            Talia_Kreator(IleKart);
            wyniki.Add(Punkty_Gracza());
            wyniki.Add(Punkty_Komputer());
            return wyniki;

        }
        public byte[] Wynik_Koncowy()
        {
            byte gracz = 0;
            byte komp = 0;
            for (int i = 0; i < wyniki.Count; i += 2)
            {
                gracz += wyniki[i];
            }
            for (int i = 1; i < wyniki.Count; i += 2)
            {
                komp += wyniki[i];
            }
            wynikKoncowy[0] = gracz;
            wynikKoncowy[1] = komp;
            return wynikKoncowy;


        }





    }
}
