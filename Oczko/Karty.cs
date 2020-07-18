using System;

namespace Oczko
{
    public class Karty
    {
        public Karty()
        {
        }

        //public Karty(Karty kolorek, Karty numerek)
        //{
        //    this.kolorek = kolorek;
        //    this.numerek = numerek;
        //}

        public enum Kolor
        {
            Kier, Karo, Pik, Trefl

        }
        public enum Numer : byte
        {
            As = 1,
            Joker =2,
            Dama,
            Król,
            Dziewiątka = 9,
            Dziesiątka,
        }
        public enum DodatkoweNumery : byte
        {
            dwójka = 2, trójka, czwórka, piątka,
            szóstka, siódemka, ósemka
        }
        public Kolor Kolorek { get; set; }
        public Numer Numerek { get; set; }
        public DodatkoweNumery DodatkoweNumerki { get; set; }

    }
}
