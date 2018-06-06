using System;
using System.Collections.Generic;

namespace ChinskiListonosz
{
    // główna klasa programu
    public class Program
    {
        // główna funkcja programu
        public static void Main(string[] args)
        {
            // zmienne lokalne
            Graf graf;
            Algorytm algorytm;
            List<Wierzcholek> cykl;

            // utworzenie grafu (graf można podejrzeć w pliku WizualizacjaGrafu.jpg)
            graf = new Graf();
            graf.DodajKrawedz("0", "4", 1.0);
            graf.DodajKrawedz("0", "5", 1.0);
            graf.DodajKrawedz("1", "2", 1.0);
            graf.DodajKrawedz("1", "3", 1.0);
            graf.DodajKrawedz("1", "4", 1.0);
            graf.DodajKrawedz("1", "5", 1.0);
            graf.DodajKrawedz("2", "3", 1.0);
            graf.DodajKrawedz("2", "4", 1.0);
            graf.DodajKrawedz("2", "5", 1.0);
            graf.DodajKrawedz("4", "5", 1.0);
            graf.DodajKrawedz("5", "6", 1.0);

            // utworzenie algorytmu
            algorytm = new Algorytm();
            // próba znalezienia cyklu
            cykl = algorytm.ZnajdzCykl(graf, graf.ZnajdzWierzcholek("0"));
            
            // wypisanie cyklu na konsolę jeżeli znaleziono
            if (cykl.Count > 0)
            {
                Console.Write("Znaleziono cykl: ");

                foreach (Wierzcholek wierzcholek in cykl)
                {
                    Console.Write(wierzcholek.Nazwa + " ");
                }
            }
            // graf nie posiada cyklu (najepewniej jest to graf niespójny)
            else
            {
                Console.WriteLine("Nie znaleziono cyklu.");
            }

            Console.WriteLine();
            // oczekiwanie, aż użytkownik wciśnie dowolny klawisz
            Console.ReadKey();
        }
    }
}
