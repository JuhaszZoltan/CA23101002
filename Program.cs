using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA23101002
{
    class Program
    {
        static void Main()
        {
            var dijazottak = new List<Dijazott>();
            using var sr = new StreamReader(
                @"..\..\..\src\orvosi_nobeldijak.txt",
                Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream) dijazottak.Add(new Dijazott(sr.ReadLine()));

            Console.WriteLine($"3. feladat: Díjazottak száma: {dijazottak.Count} fő");

            var f4 = dijazottak.Max(d => d.Ev);
            Console.WriteLine($"4. feladat: utolsó év: {f4}");

            Console.Write("5. feladat: Kérem adja meg egy ország kódját: ");
            string inputOk = Console.ReadLine();
            var f5 = dijazottak.Where(d => d.Orszag == inputOk).ToList();
            if (f5.Count == 0) Console.WriteLine("\tA megadott országból nem volt díjazott.");
            else if (f5.Count == 1)
            {
                Console.WriteLine("\tA megadott ország díjazottja:");
                Console.WriteLine($"\tNév: {f5[0].Nev}");
                Console.WriteLine($"\tÉv: {f5[0].Ev}");
                Console.WriteLine($"\tSz/H: {f5[0].SzHStr}");
            }
            else Console.WriteLine($"\tA megadott országból {f5.Count} díjazott volt.");

            Console.WriteLine("6. feladat: Statisztika");
            var f6 = dijazottak
                .GroupBy(d => d.Orszag)
                .ToDictionary(k => k.Key, v => v.Count())
                .Where(kvp => kvp.Value > 5);
            foreach (var kvp in f6) Console.WriteLine($"\t{kvp.Key,3} - {kvp.Value,2} fő");

            var f7 = dijazottak
                .Where(d => d.SzH.Halal is not null)
                .Average(d => d.SzH.Halal - d.SzH.Szuletes);
            Console.WriteLine($"7. feladat: A keresett átlag: {f7:0.0} év");
        }
    }
}
