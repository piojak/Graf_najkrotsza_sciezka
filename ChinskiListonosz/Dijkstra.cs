using System;
using System.Collections.Generic;

namespace ChinskiListonosz
{
    public class Dijkstra
    {
        public DP[] Szukaj(Graf graf, Wierzcholek start)
        {
            DP[] dp;
            List<Wierzcholek> q, s;
            Wierzcholek aktualny;
            int i, j;

            q = new List<Wierzcholek>();
            s = new List<Wierzcholek>();

            q.AddRange(graf.Wierzcholki);
            dp = new DP[q.Count];
            InicjalizujDP(dp, q);
            
            while (q.Count > 0)
            {
                i = ZnajdzIndeksMinimalny(dp, q);
                aktualny = dp[i].Wierzcholek;
                q.Remove(aktualny);
                s.Add(aktualny);

                foreach (WierzcholekKoszt sasiad in Sasiedzi(aktualny, q))
                {
                    j = ZnajdzIndeksWiercholka(dp, sasiad.Wierzcholek);

                    if (dp[j].Koszt > (dp[i].Koszt + sasiad.Koszt))
                    {
                        dp[j].Koszt = dp[i].Koszt + sasiad.Koszt;
                        dp[j].Poprzednik = i;
                    }
                }
            }

            return dp;
        }

        public List<Wierzcholek> Szukaj(Graf graf, Wierzcholek start, Wierzcholek stop)
        {
            DP[] dp;
            List<Wierzcholek> sciezka;
            int i;

            dp = Szukaj(graf, start);
            i = ZnajdzIndeksWiercholka(dp, stop);
            sciezka = new List<Wierzcholek>();

            while (i != -1)
            {
                sciezka.Insert(0, dp[i].Wierzcholek);
                i = dp[i].Poprzednik;
            }

            return sciezka;
        }

        private void InicjalizujDP(DP[] dp, List<Wierzcholek> q)
        {
            int i;

            for (i = 0; i < dp.Length; i++)
            {
                dp[i].Wierzcholek = q[i];
                dp[i].Koszt = double.MaxValue;
                dp[i].Poprzednik = -1;
            }

            dp[0].Koszt = 0.0;
        }

        private int ZnajdzIndeksMinimalny(DP[] dp, List<Wierzcholek> q)
        {
            int i, j;
            double koszt;

            j = -1;
            koszt = double.MaxValue;

            for (i = 0; i < dp.Length; i++)
            {
                if (q.Contains(dp[i].Wierzcholek))
                {
                    if (koszt > dp[i].Koszt)
                    {
                        j = i;
                        koszt = dp[i].Koszt;
                    }
                }
            }

            return j;
        }

        private int ZnajdzIndeksWiercholka(DP[] dp, Wierzcholek wierzcholek)
        {
            int i;

            for (i = 0; i < dp.Length; i++)
            {
                if (dp[i].Wierzcholek == wierzcholek)
                {
                    return i;
                }
            }

            throw new InvalidOperationException();
        }

        private IEnumerable<WierzcholekKoszt> Sasiedzi(Wierzcholek aktualny, List<Wierzcholek> q)
        {
            Wierzcholek nastepny;

            foreach (Krawedz krawedz in aktualny.Krawedzie)
            {
                nastepny = krawedz.Cel;

                if (q.Contains(nastepny))
                {
                    yield return new WierzcholekKoszt()
                    {
                        Wierzcholek = nastepny,
                        Koszt = krawedz.Waga
                    };
                }
            }
        }
    }
}
