using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hianyzasok
{
    class Program
    {
        static string hetnapja(int honap, int nap)
        {
            string[] napnev = { "vasarnap", "hetfo" , "kedd" , "szerda" , "csutortok" , "pentek" , "szombat"};
            int[] napszam = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335 };
            int napsorszam = (napszam[honap - 1] + nap) % 7;
            string hetnapja = napnev[napsorszam];
            return hetnapja;
        }
        class Naplo
        {
            public DateTime datum;
            public List<(string, string)> hianyzasok = new List<(string, string)>();
        }
        static void Main(string[] args)
        {
            List<Naplo> lista = new List<Naplo>();
            string[] sorok = File.ReadAllLines("naplo.txt");
            Naplo n = new Naplo();
            for (int i = 0; i < sorok.Count(); i++)
            {
                string[] adat = sorok[i].Split(' ');
                n = new Naplo();
                n.datum = new DateTime(1, int.Parse(adat[1]), int.Parse(adat[2]));
                do
                {
                    adat = sorok[++i].Split(' ');
                    n.hianyzasok.Add((adat[0] + " " + adat[1], adat[2]));
                } while (i < sorok.Count() - 1 && sorok[i + 1].Split(' ')[0] != "#");
                lista.Add(n);
            }

            Console.WriteLine("2. feladat");
            int db = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                db += lista[i].hianyzasok.Count();
            }
            Console.WriteLine($"A naplóban {db} bejegyzés van.");
            Console.WriteLine("3. feladat");
            int igazolt = 0;
            int igazolatlan = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                for (int j = 0; j < lista[i].hianyzasok.Count(); j++)
                {
                    igazolatlan += lista[i].hianyzasok[j].Item2.Count(x => x == 'I');
                    igazolt += lista[i].hianyzasok[j].Item2.Count(x => x == 'X');
                }
            }
            Console.WriteLine($"Az igazolt hiányzások száma {igazolt}, az igazolatlanoké {igazolatlan} óra.");
            Console.WriteLine("5. feladat");
            Console.Write("A hónap sorszáma=");
            int honap = int.Parse(Console.ReadLine());
            Console.Write("A nap sorszáma=");
            int nap = int.Parse(Console.ReadLine());
            Console.WriteLine($"Azon a napon {hetnapja(honap, nap)} volt.");
            Console.WriteLine("6. feladat");
            Console.Write("A nap neve=");
            string napneve = Console.ReadLine();
            Console.Write("A óra sorszáma=");
            int óra = int.Parse(Console.ReadLine());
            //Console.WriteLine($"Ekkor összesen {lista.First(x => hetnapja(x.datum.Month, x.datum.Day) == napneve).hianyzasok.Sum(x => x.Item2[óra] == 'I' || x.Item2[óra] == 'X')} óra hiányzás történt.");
        }
    }
}
