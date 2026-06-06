    using System;

    class Program
    {
        static void Main()
        {
            Console.Clear();
            string[] nomes = new string[100];
            double[,] notas = new double[100, 4];
            double[] medias = new double[100];
            string[] disciplinas = { "Matemática", "Português", "Ciências", "História" };
            int quantidadeAlunos = 0;
            bool rodando = true;

            while (rodando)
            {
                Console.WriteLine("| 1) 👤 Cadastrar Aluno                     |");
                Console.WriteLine("| 2) 🔍 Buscar Aluno                        |");
                Console.WriteLine("| 3) 📝 Listar Alunos                       |");
                Console.WriteLine("| 0) ❌ Sair                                |");
                Console.WriteLine();

                Console.Write("\nDigite uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("|            CADASTRAR ALUNO                |");
                        Console.Write("\nDigite o nome do aluno: ");
                        string nome = Console.ReadLine();
                        nomes[quantidadeAlunos] = nome;

                        double soma = 0;
                        for (int d = 0; d < 4; d++)
                        {
                            Console.Write($"Digite a nota em {disciplinas[d]}: ");
                            notas[quantidadeAlunos, d] = double.Parse(Console.ReadLine());
                            soma += notas[quantidadeAlunos, d];
                        }

                        medias[quantidadeAlunos] = soma / 4;
                        quantidadeAlunos++;

                        Console.WriteLine("\nAluno cadastrado com sucesso!");
                        Console.WriteLine("Aperta qualquer tecla para continuar!");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("|             BUSCAR ALUNO                  |");
                        Console.Write("\nDigite o nome do aluno: ");
                        string busca = Console.ReadLine();
                        bool encontrado = false;

                        for (int i = 0; i < quantidadeAlunos; i++)
                        {
                            if (nomes[i].ToLower() == busca.ToLower())
                            {
                                Console.WriteLine($"\nAluno: {nomes[i]}");
                                for (int d = 0; d < 4; d++)
                                {
                                    Console.WriteLine($"  {disciplinas[d]}: {notas[i, d]:F2}");
                                }
                                Console.WriteLine($"  Média: {medias[i]:F2}");
                                encontrado = true;
                                break;
                            }
                        }

                        if (!encontrado)
                            Console.WriteLine("\nAluno não encontrado!");

                        Console.WriteLine("\nAperta qualquer tecla para continuar!");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();

                        if (quantidadeAlunos > 0)
                        {
                            Console.WriteLine("|             LISTAR ALUNOS                 |");
                            Console.WriteLine("|                                           |");
                            Console.WriteLine("| A) Ordem Alfabética.                      |");
                            Console.WriteLine("| B) Maior Média de Notas.                  |");
                            Console.WriteLine("|===========================================|");
                            Console.Write("\nEscolha uma opção: ");
                            string escolha = Console.ReadLine();

                            string[] nomesTemp = (string[])nomes.Clone();
                            double[] mediasTemp = (double[])medias.Clone();

                            if (escolha.ToLower() == "a")
                            {
                                Console.Clear();
                                Array.Sort(nomesTemp, mediasTemp, 0, quantidadeAlunos);

                                Console.WriteLine("|          ALUNOS EM ORDEM ALFABÉTICA       |");
                                Console.WriteLine("|===========================================|");
                                for (int i = 0; i < quantidadeAlunos; i++)
                                {
                                    Console.WriteLine($"| {nomesTemp[i],-20} Média: {mediasTemp[i]:F2}          |");
                                }
                                Console.WriteLine("|===========================================|");
                            }
                            else if (escolha.ToLower() == "b")
                            {
                                Console.Clear();
                                Array.Sort(mediasTemp, nomesTemp, 0, quantidadeAlunos);
                                Array.Reverse(mediasTemp, 0, quantidadeAlunos);
                                Array.Reverse(nomesTemp, 0, quantidadeAlunos);

                                Console.WriteLine("|          ALUNOS POR MAIOR MÉDIA           |");
                                Console.WriteLine("|===========================================|");
                                for (int i = 0; i < quantidadeAlunos; i++)
                                {
                                    Console.WriteLine($"| {nomesTemp[i],-20} Média: {mediasTemp[i]:F2}          |");
                                }
                                Console.WriteLine("|===========================================|");
                            }
                            else
                            {
                                Console.WriteLine("Opção Incorreta!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNenhum aluno cadastrado!");
                        }

                        Console.WriteLine("\nAperta qualquer tecla para continuar!");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 0:
                        Console.Clear();
                        rodando = false;
                        Console.WriteLine("\nSaindo...");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nOpção Inválida!");
                        Console.WriteLine("Aperta qualquer tecla para continuar!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }