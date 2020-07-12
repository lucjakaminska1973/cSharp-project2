namespace Oczko
{
    public interface IKarty_W_Grze
    {
        byte Punkty_W_Grze();
        byte WylosujKarte();
        void Wypisz_Karte(Karty karty, byte index);
        void Wypisz_Punkty();
        void Wypisz_Punkty(Punkty punkty);
        string Zapytaj();
        byte Za_ile_As();
    }
}