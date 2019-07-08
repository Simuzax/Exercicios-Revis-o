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

        void RoubarVida(Personagem alvo)
        {
            int lifesteal = (int)(alvo.Hp * 0.1);

            alvo.Hp -= (int)(alvo.Hp * 0.1);
            Hp += lifesteal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Guerreiro guerreiro = new Guerreiro();
            Inimigo inimigo = new Inimigo();

            Console.WriteLine("Digite o nome do seu Guerreiro:");
            guerreiro.nome = Console.ReadLine();

            Console.WriteLine("Digite o nome do Inimigo:");
            inimigo.nome = Console.ReadLine();

            Console.WriteLine("-------------------------");
            Console.WriteLine("Digite o HP do Guerreiro:");
            guerreiro.Hp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a Força do Guerreiro:");
            guerreiro.Força = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("-----------------------");
            Console.WriteLine("Digite o HP do Inimigo:");
            inimigo.Hp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a Força do Inimigo:");
            inimigo.Força = Convert.ToInt32(Console.ReadLine());
        }
    }
}
