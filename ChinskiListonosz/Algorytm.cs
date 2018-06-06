using System;
using System.Collections.Generic;

namespace ChinskiListonosz
{
    // algorytm szukający ścieżki w Problemie Chińskiego Listonosza
    public class Algorytm
    {
        // metoda publiczna zwracająca listę wierzchołków wchodzących w skład cyklu
        public List<Wierzcholek> ZnajdzCykl(Graf graf, Wierzcholek poczatek)
        {
            List<Wierzcholek> rezultat;

            rezultat = new List<Wierzcholek>();

            if (!graf.PosiadaCyklEulera())
            {
                UzupelnijNieparzysteKrawedzie(graf);
            }

            ZnajdzCyklRekurencyjnie(poczatek, ref rezultat);

            return rezultat;
        }

        // metoda prywatna szukająca cyklu rekurencyjnie
        private void ZnajdzCyklRekurencyjnie(Wierzcholek wierzcholek, ref List<Wierzcholek> rezultat)
        {
            Krawedz krawedz;

            while (wierzcholek.Krawedzie.Count > 0)
            {
                krawedz = wierzcholek.Krawedzie[0];
                UsunKrawedz(wierzcholek, krawedz, 0);
                ZnajdzCyklRekurencyjnie(krawedz.Cel, ref rezultat);
            }

            rezultat.Add(wierzcholek);
        }

        private void UzupelnijNieparzysteKrawedzie(Graf graf)
        {
            Wierzcholek a, b;
            Dijkstra dijkstra;
            List<Wierzcholek> sciezka;
            int i;

            dijkstra = new Dijkstra();

            while (true)
            {
                a = null;

                foreach (Wierzcholek wierzcholek in graf.Wierzcholki)
                {
                    if ((wierzcholek.Krawedzie.Count % 2) != 0)
                    {
                        a = wierzcholek;
                        break;
                    }
                }

                b = null;

                foreach (Wierzcholek wierzcholek in graf.Wierzcholki)
                {
                    if (wierzcholek != a && (wierzcholek.Krawedzie.Count % 2) != 0)
                    {
                        b = wierzcholek;
                        break;
                    }
                }

                if (a == null && b == null)
                {
                    break;
                }

                sciezka = dijkstra.Szukaj(graf, a, b);

                for (i = 0; i < sciezka.Count - 1; i++)
                {
                    graf.DodajKrawedz(sciezka[i].Nazwa, sciezka[i + 1].Nazwa, 1.0);
                }
            }
        }

        // metoda pomocnicza usuwająca krawędź (usuwa krawędź A -> B oraz B -> A)
        private void UsunKrawedz(Wierzcholek wierzcholek, Krawedz krawedz, int i)
        {
            Krawedz symetryczna;

            wierzcholek.Krawedzie.RemoveAt(i);
            symetryczna = krawedz.Cel.Krawedzie.Find((w) => w.Cel == wierzcholek);
            krawedz.Cel.Krawedzie.Remove(symetryczna);
        }
    }
}
