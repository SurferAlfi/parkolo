using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Parkolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Parkol> parkolok = new List<Parkol>();
            try
            {
                StreamReader sr = new StreamReader("teszt.txt");
                while (!sr.EndOfStream)
                {
                    parkolok.Add(new Parkol(sr.ReadLine()));
                }
                sr.Close();
                Console.WriteLine("a járművek listája:");
                List<string> list = new List<string>();
                foreach (Parkol item in parkolok)
                {
                    list.Add(item.ToString());
                }
                foreach (var item in list)
                    Console.WriteLine(item);

                int lri = 0;
                for (int i = 0; i < parkolok.Count; i++)
                {
                    if (parkolok[lri].Fizetes() > 0)
                    {
                        if (parkolok[i].Fizetes() > 0 && parkolok[lri].ParkolasiIdo > parkolok[i].ParkolasiIdo)
                            lri = i;
                    }
                    else
                    {
                        lri = i;
                    }
                }
                Console.WriteLine("\nA legrövidebb ideig parkoló fizető jármű: ");
                Console.WriteLine(parkolok[lri]);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
