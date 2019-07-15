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
        public int Id, HpBase, ForçaBase;

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

        public virtual void MostrarDados()
        {
            Console.WriteLine("HP e Força atual de " + nome + ": " + Hp + " e " + Força);
        }

        public virtual void Atacar(Personagem alvo)
        {
            alvo.Hp -= Força;
        }

        public virtual void AcoesDisponiveis()
        {
            Console.WriteLine("Ações possíveis: Atacar");
        }
    }

    class Guerreiro : Personagem
    {
        public virtual void AumentarForça()
        {
            Hp -= 5;
            Força += 5;
        }

        public override void AcoesDisponiveis()
        {
            Console.WriteLine("Ações possíveis: Atacar, Aumentar Dano");
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

        public override void AcoesDisponiveis()
        {
            Console.WriteLine("Ações possíveis: Atacar, Roubar Vida");
        }
    }

    class Mago : Personagem
    {
        public int MpBase;

        private double mp_;
        public double Mp
        {
            get
            {
                return mp_;
            }
            set
            {
                mp_ = value;
            }
        }

        public void BolaDeFogo(Personagem alvo)
        {
            Mp -= 5;
            alvo.Hp -= 20;
        }

        public override void MostrarDados()
        {
            Console.WriteLine("HP, Força e MP atual de " + nome + ": " + Hp + ", " + Força + " e " + Mp);
        }

        public override void AcoesDisponiveis()
        {
            Console.WriteLine("Ações possíveis: Atacar, Bola de Fogo");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Personagem> listaPersonagens = new List<Personagem>();

            int id = 0;
            int lifesteal;

            int comandoent = -1;
            int comando;

            //Pré-Criação
            while (comandoent != 0)
            {
                Console.WriteLine("Que tipo de personagem deseja criar?");
                Console.WriteLine("1 - Guerreiro");
                Console.WriteLine("2 - Inimigo");
                Console.WriteLine("3 - Mago");
                Console.WriteLine("0 - Parar de criar");

                comando = Convert.ToInt32(Console.ReadLine());

                switch (comando)
                {
                    case 1:
                        Guerreiro guerreiro1 = new Guerreiro();

                        Console.WriteLine("Escolha o nome do Guerreiro");
                        guerreiro1.nome = Console.ReadLine();

                        Console.WriteLine("Escolha o HP do Guerreiro");
                        guerreiro1.Hp = guerreiro1.HpBase = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Escolha a Força do Guerreiro");
                        guerreiro1.Força = guerreiro1.ForçaBase = Convert.ToInt32(Console.ReadLine());

                        id++;
                        guerreiro1.Id = id;

                        Console.WriteLine("O ID do Guerreiro é: " + guerreiro1.Id);
                        Console.WriteLine("----------------");

                        listaPersonagens.Add(guerreiro1);

                        break;

                    case 2:
                        Inimigo inimigo1 = new Inimigo();

                        Console.WriteLine("Escolha o nome do Inimigo");
                        inimigo1.nome = Console.ReadLine();

                        Console.WriteLine("Escolha o HP do Inimigo");
                        inimigo1.Hp = inimigo1.HpBase = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Escolha a Força do Inimigo");
                        inimigo1.Força = inimigo1.ForçaBase = Convert.ToInt32(Console.ReadLine());

                        id++;
                        inimigo1.Id = id;

                        Console.WriteLine("O ID do Inimigo é: " + inimigo1.Id);
                        Console.WriteLine("----------------");

                        listaPersonagens.Add(inimigo1);

                        break;

                    case 3:
                        Mago mago1 = new Mago();

                        Console.WriteLine("Escolha o nome do Mago");
                        mago1.nome = Console.ReadLine();

                        Console.WriteLine("Escolha o HP do Mago");
                        mago1.Hp = mago1.HpBase = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Escolha a Força do Mago");
                        mago1.Força = mago1.ForçaBase = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Escolha a Mana do Mago");
                        mago1.Mp = mago1.MpBase = Convert.ToInt32(Console.ReadLine());

                        id++;
                        mago1.Id = id;

                        Console.WriteLine("O ID do Mago é: " + mago1.Id);
                        Console.WriteLine("----------------");

                        listaPersonagens.Add(mago1);

                        break;

                    case 0:
                        comandoent = 0;
                        break;
                }
            }

            comandoent = -1;

            Personagem alvoP = new Personagem();
            Personagem atacanteP = new Personagem();

            //Pós-Criação
            while (comandoent != 0)
            {
                //ATACANTE
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Escolha o Personagem que realizará o ataque:");
                Console.WriteLine("1 - Escolher Atacante por Nome");
                Console.WriteLine("2 - Escolher Atacante por ID");
                Console.WriteLine("0 - Fechar o programa");

                comando = Convert.ToInt32(Console.ReadLine());

                switch (comando)
                {
                    //por Nome
                    case 1:
                        atacanteP = listaPersonagens.Find(x => x.nome == Console.ReadLine());
                        break;

                    //por ID
                    case 2:
                        atacanteP = listaPersonagens.Find(x => x.Id == Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 0:
                        comandoent = 0;
                        break;
                }

                if (atacanteP.GetType() == typeof(Guerreiro))
                {
                    Guerreiro atacante = (Guerreiro)atacanteP;
                }

                if (atacanteP.GetType() == typeof(Inimigo))
                {
                    Inimigo atacante = (Inimigo)atacanteP;
                }

                if (atacanteP.GetType() == typeof(Mago))
                {
                    Mago atacante = (Mago)atacanteP;
                }

                //ALVO
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Agora escolha o Alvo que receberá o ataque:");
                Console.WriteLine("1 - Escolher Alvo por Nome");
                Console.WriteLine("2 - Escolher Alvo por ID");
                Console.WriteLine("0 - Fechar o programa");

                comando = Convert.ToInt32(Console.ReadLine());

                switch (comando)
                {

                    //por Nome
                    case 1:
                        alvoP = listaPersonagens.Find(x => x.nome == Console.ReadLine());
                        break;

                    //por ID
                    case 2:
                        alvoP = listaPersonagens.Find(x => x.Id == Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 0:
                        comandoent = 0;
                        break;
                }

                if (alvoP.GetType() == typeof(Guerreiro))
                {
                    Guerreiro alvo = (Guerreiro)alvoP;
                }

                if (alvoP.GetType() == typeof(Inimigo))
                {
                    Inimigo alvo = (Inimigo)alvoP;
                }

                if (alvoP.GetType() == typeof(Mago))
                {
                    Mago alvo = (Mago)alvoP;
                }

                Console.WriteLine("-------------------------");
                Console.WriteLine("O que deseja fazer agora?");
                Console.WriteLine("1 - Mostrar os dados do Alvo e do Atacante escolhidos");
                Console.WriteLine("2 - Mostrar ações possiveis a serem realizados");

                comando = Convert.ToInt32(Console.ReadLine());

                switch (comando)
                {
                    case 1:
                        Console.WriteLine("Dados do Atacante:");
                        atacanteP.MostrarDados();

                        Console.WriteLine("Dados do Alvo:");
                        alvoP.MostrarDados();

                        break;

                    case 2:
                        atacanteP.AcoesDisponiveis();
                        break;
                }

                Console.WriteLine("-------------------------");
                Console.WriteLine("Que tipo de ataque deseja realizar?");
                Console.WriteLine("1 - Atacar");

                if (atacanteP.GetType() == typeof(Guerreiro))
                    Console.WriteLine("2 - Aumentar Força");

                if (atacanteP.GetType() == typeof(Inimigo))
                    Console.WriteLine("2 - Roubar Vida");

                if (atacanteP.GetType() == typeof(Mago))
                    Console.WriteLine("2 - Bola de Fogo");

                Console.WriteLine("3 - Resetar os valores do Atacante para os seus Iniciais");
                Console.WriteLine("4 - Resetar os valores do Alvo para os seus Iniciais");
                Console.WriteLine("5 - Resetar os valores de todos os personagens não-Inimigos para o seu valor inicial");
                Console.WriteLine("6 - Resetar os valores de todos os personagens Inimigos para o seu valor inicial");
                Console.WriteLine("7 - Mostrar os dados de todos os Personagens Cadastrados");
                Console.WriteLine("0 - Fechar o programa");

                comando = Convert.ToInt32(Console.ReadLine());

                switch (comando)
                {
                    case 1:
                        atacanteP.Atacar(alvoP);
                        break;

                    case 2:
                        if (atacanteP.GetType() == typeof(Guerreiro))
                            atacanteP.AumentarForça();

                        if (atacanteP.GetType() == typeof(Inimigo))
                            atacanteP.RoubarVida(alvoP);

                        if (atacanteP.GetType() == typeof(Mago))
                            atacanteP.BolaDeFogo(alvoP);

                        break;

                    case 3:
                        atacanteP.Hp = atacanteP.HpBase;
                        atacanteP.Força = atacanteP.ForçaBase;

                        if (atacanteP.GetType() == typeof(Mago))
                            atacanteP.Mp = atacanteP.MpBase;

                        break;

                    case 4:
                        alvoP.Hp = alvoP.HpBase;
                        alvoP.Força = alvoP.ForçaBase;

                        if (alvoP.GetType() == typeof(Mago))
                            alvoP.Mp = alvoP.MpBase;

                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 0:
                        comandoent = 0;
                        break;
                }
            }
        }
    }
};