using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valores = new int[5];
            int negativos = 0;
            Console.WriteLine("Digite 5 valores, 1 por linha, que direi quantos são negativos:");

            for (int i = 0; i < valores.Length; i++)
            {
                valores[i] = Convert.ToInt32(Console.ReadLine());

                if (valores[i] < 0) negativos++;

            }

            Console.WriteLine("A quantidade de números negativos é: " + negativos);

            Console.ReadKey();
        }
    }
}