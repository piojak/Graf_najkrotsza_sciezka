using System;
using System.Collections.Generic;

namespace ChinskiListonosz
{
    // klasa grafu
    public class Graf
    {
        // lista wierzchołków
        private List<Wierzcholek> wierzcholki;

        // konstruktor
        public Graf()
        {
            wierzcholki = new List<Wierzcholek>();
        }

        // dodaje krawędź do grafu
        public void DodajKrawedz(string a, string b, double waga)
        {
            Wierzcholek wierzcholekA, wierzcholekB;

            wierzcholekA = wierzcholki.Find((w) => w.Nazwa == a);
            wierzcholekB = wierzcholki.Find((w) => w.Nazwa == b);

            if (wierzcholekA == null)
            {
                wierzcholekA = new Wierzcholek(a);
                wierzcholki.Add(wierzcholekA);
            }

            if (wierzcholekB == null)
            {
                wierzcholekB = new Wierzcholek(b);
                wierzcholki.Add(wierzcholekB);
            }

            wierzcholekA.DodajKrawedz(wierzcholekB, waga);
            wierzcholekB.DodajKrawedz(wierzcholekA, waga);
        }

        // szuka wierzchołka w grafie
        public Wierzcholek ZnajdzWierzcholek(string nazwa)
        {
            return wierzcholki.Find(w => w.Nazwa == nazwa);
        }

        // sprawdza czy graf posiada cykl Eulera
        public bool PosiadaCyklEulera()
        {
            foreach (Wierzcholek wierzcholek in wierzcholki)
            {
                // wierchołek musi mieć krawędzie wyjściowe w parzystej ilości
                if (wierzcholek.Krawedzie.Count == 0 || (wierzcholek.Krawedzie.Count % 2) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public List<Wierzcholek> Wierzcholki => wierzcholki;
    }
}
