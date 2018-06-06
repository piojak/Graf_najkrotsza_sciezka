using System.Collections.Generic;

namespace ChinskiListonosz
{
    // klasa wierzchołka
    public class Wierzcholek
    {
        // nazwa wierzchołka
        private string nazwa;
        // lista krawędzi
        private List<Krawedz> krawedzie;

        // konstruktor
        public Wierzcholek(string nazwa)
        {
            this.nazwa = nazwa;
            krawedzie = new List<Krawedz>();
        }

        // dodaje krawędź
        public void DodajKrawedz(Wierzcholek cel, double waga)
        {
            krawedzie.Add(new Krawedz(cel, waga));
        }

        // akcesory
        public string Nazwa => nazwa;
        public List<Krawedz> Krawedzie => krawedzie;

        public override string ToString()
        {
            return nazwa;
        }
    }
}
