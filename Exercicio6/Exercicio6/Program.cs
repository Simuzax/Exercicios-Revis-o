using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_6
{
    public class Calculadora
    {
        static public double soma(double a, double b)
        {
            return a + b;
        }
        static public double subtracao(double a, double b)
        {
            return a - b;
        }
        static public double multiplicacao(double a, double b)
        {
            return a * b;
        }
        static public double divisao(double a, double b)
        {
            return a / b;
        }
    }
    class CalculadoraCientifica : Calculadora
    {
        static public double raiz(double a)
        {
            return Math.Sqrt(a);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int comando;
            double numero1, numero2;

            Console.WriteLine("Que tipo de função deseja fazer?:");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Raiz");

            comando = Convert.ToInt32(Console.ReadLine());

            if (comando == 5)
            {
                Console.WriteLine("Digite o valor que você deseja saber a raiz:");
                numero1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Resultado: " + CalculadoraCientifica.raiz(numero1));
            }
            else
            {
                Console.WriteLine("Digite o valor inicial:");
                numero1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite o segundo valor:");
                numero2 = Convert.ToInt32(Console.ReadLine());

                switch (comando)
                {
                    case 1:
                        Console.WriteLine("Resposta: " + Calculadora.soma(numero1, numero2));
                        break;
                    case 2:
                        Console.WriteLine("Resposta: " + Calculadora.subtracao(numero1, numero2));
                        break;
                    case 3:
                        Console.WriteLine("Resposta: " + Calculadora.multiplicacao(numero1, numero2));
                        break;
                    case 4:
                        Console.WriteLine("Resposta: " + Calculadora.divisao(numero1, numero2));
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
