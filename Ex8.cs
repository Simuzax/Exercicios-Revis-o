using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Personagem
    {
        public string nome;

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

        public void MostrarDados()
        {
            Console.WriteLine("HP e Força atual do " + nome + ": " + Hp + " e " + Força);
        }

        public virtual void Atacar(Personagem alvo)
        {
            alvo.Hp -= Força;
        }
    }

    class Guerreiro : Personagem
    {
        public virtual void AumentarForça()
        {
            Hp -= 5;
            Força += 5;
        }
    }

    class Inimigo : Personagem
    {
        public override void Atacar(Personagem alvo)
        {
            alvo.Hp -= (int)(alvo.Hp * 0.3);
        }

        public int RoubarVida(Personagem alvo)
        {
            int lifesteal = (int)(alvo.Hp * 0.1);

            alvo.Hp -= lifesteal;
            Hp += lifesteal;

            return lifesteal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int guerreiroHpBase, guerreiroForçaBase, inimigoHpBase, inimigoForçaBase, lifesteal;

            Guerreiro guerreiro = new Guerreiro();
            Inimigo inimigo = new Inimigo();

            Console.WriteLine("Digite o nome do seu Guerreiro:");
            guerreiro.nome = Console.ReadLine();

            Console.WriteLine("Digite o nome do Inimigo:");
            inimigo.nome = Console.ReadLine();

            Console.WriteLine("-------------------------");
            Console.WriteLine("Digite o HP de " + guerreiro.nome + ":");
            guerreiroHpBase = Convert.ToInt32(Console.ReadLine());
            guerreiro.Hp = guerreiroHpBase;

            Console.WriteLine("Digite a Força de " + guerreiro.nome + ":");
            guerreiroForçaBase = Convert.ToInt32(Console.ReadLine());
            guerreiro.Força = guerreiroForçaBase;

            Console.WriteLine("-----------------------");
            Console.WriteLine("Digite o HP de " + inimigo.nome + ":");
            inimigoHpBase = Convert.ToInt32(Console.ReadLine());
            inimigo.Hp = inimigoHpBase;

            Console.WriteLine("Digite a Força de " + inimigo.nome + ":");
            inimigoForçaBase = Convert.ToInt32(Console.ReadLine());
            inimigo.Força = inimigoForçaBase;

            Console.WriteLine();

            int comando = -1;

            while (comando != 0)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("O que deseja fazer agora?");
                Console.WriteLine("(Digite um dos valores a seguir para realizar uma ação)");
                Console.WriteLine();
                Console.WriteLine("1 - " + guerreiro.nome + " atacar " + inimigo.nome);
                Console.WriteLine("2 - " + inimigo.nome + " atacar " + guerreiro.nome);
                Console.WriteLine("3 - " + guerreiro.nome + " aumenta sua força");
                Console.WriteLine("4 - " + inimigo.nome + " rouba vida do " + guerreiro.nome);
                Console.WriteLine("5 - Mostrar dados do " + guerreiro.nome + " e do " + inimigo.nome);
                Console.WriteLine("6 - Resetar os valores do " + guerreiro.nome + " para os valores base");
                Console.WriteLine("7 - Resetar os valores do " + inimigo.nome + " para os valores base");
                Console.WriteLine("0 - Sair do Programa");
                Console.WriteLine();

                comando = Convert.ToInt32(Console.ReadLine());

                switch (comando)
                {
                    case 1:
                        guerreiro.MostrarDados();
                        inimigo.MostrarDados();
                        Console.WriteLine(guerreiro.nome + " ataca " + inimigo.nome);
                        guerreiro.Atacar(inimigo);
                        Console.WriteLine("O HP de " + inimigo.nome + " diminui para: " + inimigo.Hp);
                        break;
                    case 2:
                        guerreiro.MostrarDados();
                        inimigo.MostrarDados();
                        Console.WriteLine(inimigo.nome + " ataca " + guerreiro.nome);
                        inimigo.Atacar(guerreiro);
                        Console.WriteLine("O HP de " + guerreiro.nome + " diminui para: " + guerreiro.Hp);
                        break;
                    case 3:
                        Console.WriteLine("HP e Força atual: " + guerreiro.Hp + ", " + guerreiro.Força);
                        Console.WriteLine(guerreiro.nome + " aumenta sua força");
                        guerreiro.AumentarForça();
                        Console.WriteLine("Seu HP diminui para: " + guerreiro.Hp);
                        Console.WriteLine("Sua Força aumenta para: " + guerreiro.Força);
                        break;
                    case 4:
                        guerreiro.MostrarDados();
                        inimigo.MostrarDados();
                        Console.WriteLine(inimigo.nome + " rouba vida");
                        lifesteal = inimigo.RoubarVida(guerreiro);
                        Console.WriteLine(inimigo.nome + " se cura em: " + lifesteal);
                        Console.WriteLine(guerreiro.nome + " recebe " + lifesteal + " de dano");
                        break;
                    case 5:
                        guerreiro.MostrarDados();
                        Console.WriteLine();
                        inimigo.MostrarDados();
                        break;
                    case 6:
                        guerreiro.Hp = guerreiroHpBase;
                        guerreiro.Força = guerreiroForçaBase;
                        Console.WriteLine("Valores resetados");
                        break;
                    case 7:
                        inimigo.Hp = inimigoHpBase;
                        inimigo.Força = inimigoForçaBase;
                        Console.WriteLine("Valores resetados");
                        break;
                    case 0:
                        comando = 0;
                        break;
                }
            }
        }
    }
}