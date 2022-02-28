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
        class Naplo
        {
            public DateTime datum;
            public List<(string, string)> hianyzas = new List<(string, string)>();
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
                    n.hianyzas.Add((adat[0] + " " + adat[1], adat[2]));
                } while (i < sorok.Count() && sorok[++i].Split(' ')[0] != "#");
                lista.Add(n);
            }
        }
    }
}
