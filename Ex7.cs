using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{           
    abstract class Figura
    {
        private double x;
        public double xp
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public virtual double CalcularArea()
        {
            return x;
        }

        public virtual double CalcularPerimetro()
        {
            return x;
        }
    }

    class Equilatero : Figura
    {
        public override double CalcularArea()
        {
            return (xp * xp) / 2;
        }
    }

    class Quadrado : Figura
    {

    }

    class Circulo : Figura
    {

    }

    class Pentagono : Figura
    {

    }

    class Hexagono : Figura
    {

    }   

    class Heptagono : Figura
    {

    }

    class Octogono : Figura
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            string figura = "sla";

            Console.WriteLine("Informe os dados a seguir:");

            /*Equilatero teste = new Equilatero();

            teste.xp = 3;

            Console.WriteLine(teste.CalcularArea());*/

            figura = Console.ReadLine();
            figura = figura.ToUpper();

            switch (figura)
            {
                case "EQUILÁTERO":
                case "EQUILATERO":
                    break;

                case "QUADRADO":
                    break;

                case "CÍRCULO":
                case "CIRCULO":
                    break;

                case "PENTÁGONO":
                case "PENTAGONO":
                    break;

                case "HEXÁGONO":
                case "HEXAGONO":
                    break;

                case "HEPTÁGONO":
                case "HETPAGONO":
                    break;

                case "OCTÓGONO":
                case "OCTOGONO":
                    break;
            }
        }
    }
}
