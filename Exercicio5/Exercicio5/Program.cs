using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_5
{
    class Personagem
    {
        public enum Cores
        {
            Azul,
            Castanho,
            Verde,
            Louro,
            Preto
        }
        public Cores olhos;
        public Cores cabelo;
        public bool homem;
        public int level;
        public void print()
        {
            Console.WriteLine("level:" + level);
            Console.WriteLine("homem:" + homem);
            Console.WriteLine("olhos:" + olhos);
            Console.WriteLine("cabelo:" + cabelo);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Personagem> listaPersonagens = new List<Personagem>();
            int level = 1;
            while (level >= 0)
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Digite o level do jogador, use um número negativo para parar:");
                level = Convert.ToInt32(Console.ReadLine());
                if (level < 0) break;

                Personagem cobaia = new Personagem();
                cobaia.level = level;

                Console.WriteLine("Digite o sexo do jogador, m para homem, e f para mulher:");
                string entrada = Console.ReadLine();
                entrada = entrada.ToLower();
                cobaia.homem = (entrada == "m");


                Console.WriteLine("Digite a cor dos olhos do personagem (Azul, Castanho ou Verde):");
                entrada = Console.ReadLine();
                entrada = entrada.ToLower();
                switch (entrada)
                {
                    case "azul":
                        cobaia.olhos = Personagem.Cores.Azul;
                        break;
                    case "castanho":
                        cobaia.olhos = Personagem.Cores.Castanho;
                        break;
                    case "verde":
                        cobaia.olhos = Personagem.Cores.Verde;
                        break;
                    default:
                        Console.WriteLine("Cor inválida, auomaticamente definida como castanho.");
                        goto case "castanho";
                        break;
                }

                Console.WriteLine("Digite a cor dos cabelos do personagem (Preto, Castanho ou Louro):");
                entrada = Console.ReadLine();
                entrada = entrada.ToLower();
                switch (entrada)
                {
                    case "castanho":
                        cobaia.cabelo = Personagem.Cores.Castanho;
                        break;
                    case "louro":
                        cobaia.cabelo = Personagem.Cores.Louro;
                        break;
                    case "preto":
                        cobaia.cabelo = Personagem.Cores.Preto;
                        break;
                    default:
                        Console.WriteLine("Cor inválida, auomaticamente definida como castanho.");
                        goto case "castanho";
                        break;
                }
                listaPersonagens.Add(cobaia);
            }
            int mulheres = listaPersonagens.FindAll
                (x => x.level >= 18 && x.level <= 35
                && x.cabelo == Personagem.Cores.Louro && x.olhos == Personagem.Cores.Verde
                && !x.homem).Count;
            int percentual = listaPersonagens.FindAll
                (x => x.cabelo != Personagem.Cores.Louro && x.olhos != Personagem.Cores.Azul).Count;
            List<int> leveis = listaPersonagens.Select(x => x.level).ToList();
            leveis.Sort();
            Console.WriteLine("Quantidade de mulheres com olhos Verdes, cabelos Louros, do level 18 ao 35: " + mulheres);
            Console.WriteLine("Percentual de personagens que não são louros e nem tem olhos azuis: " + (double)percentual / (double)listaPersonagens.Count * 100);
            Console.WriteLine("Perosnagem com o maior level: " + leveis.Last());
            Console.ReadKey();
        }
    }
}
