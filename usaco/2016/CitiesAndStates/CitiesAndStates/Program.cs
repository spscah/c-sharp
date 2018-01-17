using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CitiesAndStates
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> lines = File.ReadAllLines(@"C:\Users\cah\Downloads\citystate_silver_dec16\" + args[0] + ".in").ToList();

            IDictionary<string, int> codes = new Dictionary<string, int>();

            for (int i = 1; i < lines.Count; i++)
            {
                IList<string> splits = lines[i].Split(' ');
                string code = splits[0].Substring(0, 2) + splits[1].Substring(0, 2);

                if (!codes.ContainsKey(code))
                        codes.Add(code, 0);
                codes[code]++;
                
            }

            int counter = 0;
            foreach(string code in codes.Keys)
            {
                string reverse = code.Substring(2, 2) + code.Substring(0, 2);
                if (code == reverse)
                    continue;
                if (codes.ContainsKey(reverse))
                    counter += codes[code] * codes[reverse];
            }

            Console.WriteLine(counter / 2);
            Console.ReadLine();

        }
    }
}
