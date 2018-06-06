namespace ChinskiListonosz
{
    // krawedź grafu
    public class Krawedz
    {
        // wierzchołek docelowy
        private Wierzcholek cel;
        // waga połączenia
        private double waga;

        // konstruktor
        public Krawedz(Wierzcholek cel, double waga)
        {
            this.cel = cel;
            this.waga = waga;
        }

        // akcesory
        public Wierzcholek Cel => cel;
        public double Waga => waga;
    }
}
