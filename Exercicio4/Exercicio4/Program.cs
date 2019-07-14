using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio_4
{
    internal class Cobaias
    {
        public char Sexo = 'K';

        private int hp_;

        public int Hp
        {
            get
            {
                return hp_;
            }
            set
            {
                hp_ = value;
            }
        }

        private int força_;

        public int Força
        {
            get
            {
                return força_;
            }
            set
            {
                força_ = value;
            }
        }

        private int defesa_;

        public int Defesa
        {
            get
            {
                return defesa_;
            }
            set
            {
                defesa_ = value;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Cobaias> Cobaias = new List<Cobaias>();

            int input = -1;
            while (input != 0)
            {
                Console.WriteLine("==============================================================");

                Cobaias cobaia = new Cobaias();

                Console.WriteLine("Escreva o HP do inimigo:");

                cobaia.Hp = Convert.ToInt32(Console.ReadLine());
                if (cobaia.Hp < 0)
                {
                    Console.WriteLine("HP digitado foi negativo, HP foi definido como 0.");
                    cobaia.Hp = 0;
                    Console.WriteLine("==============================================================");
                }

                Console.WriteLine("Escreva o Sexo do inimigo, F - Para mulheres, e M - para homens:");
                cobaia.Sexo = Console.ReadLine().ToUpper()[0];
                Console.WriteLine("==============================================================");

                Console.WriteLine("Escreva a Força do inimigo:");
                cobaia.Força = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("==============================================================");

                Console.WriteLine("Escreva a Defesa do inimigo:");
                cobaia.Defesa = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("==============================================================");

                Cobaias.Add(cobaia);

                Console.WriteLine("Digite de 1 a 9 para adicionar outra cobaia");
                Console.WriteLine("Digite 0 para parar o programa");
                Console.WriteLine("==============================================================");

                input = Convert.ToInt32(Console.ReadLine());
            }
            List<int> hps = Cobaias.Select(x => x.Hp).ToList();
            hps.Sort();

            Console.WriteLine("==============================================================");

            Console.WriteLine("Média de HP do grupo:");
            Console.WriteLine(hps.Average());

            Console.WriteLine("Maior HP do grupo:");
            Console.WriteLine(hps.Last());

            Console.WriteLine("Menor HP do grupo:");
            Console.WriteLine(hps.First());

            Console.WriteLine("Mulheres com Força até 50:");
            Console.WriteLine(Cobaias.FindAll(x => x.Força <= 50 && x.Sexo == 'F').Count);

            Console.WriteLine("Homens com Força e Defesa maiores que 35");
            Console.WriteLine(Cobaias.FindAll(x => x.Força > 35 && x.Defesa > 35 && x.Sexo == 'M').Count);

            Console.WriteLine("==============================================================");

            Console.ReadKey();
        }
    }
}