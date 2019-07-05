using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> gold = new List<double>();
            List<double> mounts = new List<double>();

            double val = -1;
            while (val != 0)
            {
                //Gold
                Console.WriteLine("Digite a quantidade de Gold de um personagem");
                val = (Convert.ToInt32(Console.ReadLine()));

                if (val > 0)
                    gold.Add(val);
                else if (val < 0)
                {
                    Console.WriteLine("Número negativo, pararemos a contagem");
                    break;
                }

                //Montarias
                Console.WriteLine("Digite a quantidade de Montarias de um personagem");
                val = (Convert.ToInt32(Console.ReadLine()));

                if (val > 0)
                    mounts.Add(val);
                else if (val < 0)
                {
                    Console.WriteLine("Número negativo, pararemos a contagem");
                    break;
                }
            }

            Console.WriteLine("Média de Gold dos personagens:");
            Console.WriteLine(gold.Average());

            Console.WriteLine("Média de Montarias dos personagens:");
            Console.WriteLine(mounts.Average());

            Console.WriteLine("Maior valor de Gold de um personagem:");
            gold.Sort();
            Console.WriteLine(gold.Last());

            Console.WriteLine("Percentural de personagens com até 100 de Gold:");
            Console.WriteLine(((gold.FindAll(x => x <= 100).Count) / gold.Count) * 100);

            Console.ReadKey();
        }
    }
}
