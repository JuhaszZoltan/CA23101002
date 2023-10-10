using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA23101002
{
    class Dijazott
    {
        public int Ev { get; set; }
        public string Nev { get; set; }
        public string SzHStr { get; set; }
        public (int Szuletes, int? Halal) SzH { get; set; }
        public string Orszag { get; set; }

        public Dijazott(string s)
        {
            var v = s.Split(';');
            Ev = int.Parse(v[0]);
            Nev = v[1];
            SzHStr = v[2];
            var szhv = v[2].Split('-');
            SzH = (
                Szuletes: int.Parse(szhv[0]),
                Halal: szhv[1].Length == 0 ? null : int.Parse(szhv[1]));
            Orszag = v[3];
        }
    }
}
