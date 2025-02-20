using System;
using System.IO;

class ProgramaGerenciador
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1 - Criar Pasta");
            Console.WriteLine("2 - Criar Arquivo .TXT");
            Console.WriteLine("3 - Listar Arquivos na Pasta");
            Console.WriteLine("4 - Renomear Arquivo");
            Console.WriteLine("5 - Deletar Arquivo");
            Console.WriteLine("6 - Deletar Pasta");
            Console.WriteLine("7 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarPasta();
                    break;
                case "2":
                    CriarArquivo();
                    break;
                case "3":
                    ListarArquivos();
                    break;
                case "4":
                    RenomearArquivo();
                    break;
                case "5":
                    DeletarArquivo();
                    break;
                case "6":
                    DeletarPasta();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }


    static void CriarPasta()
    {
        Console.Write("Digite o nome da pasta: ");
        string nomePasta = Console.ReadLine();

        if (Directory.Exists(nomePasta))
        {
            Console.WriteLine(" A pasta já existe!");
        }
        else
        {
            Directory.CreateDirectory(nomePasta);
            Console.WriteLine(" Pasta criada com sucesso!");
        }
    }


    static void CriarArquivo()
    {
        Console.Write("Digite o nome da pasta onde deseja criar o arquivo: ");
        string pasta = Console.ReadLine();

        if (!Directory.Exists(pasta))
        {
            Console.WriteLine(" A pasta não existe!");
            return;
        }

        Console.Write("Digite o nome do arquivo (exemplo: meuArquivo.txt): ");
        string nomeArquivo = Console.ReadLine();
        string caminhoArquivo = Path.Combine(pasta, nomeArquivo);

        Console.Write("Digite o conteúdo do arquivo: ");
        string conteudo = Console.ReadLine();

        File.WriteAllText(caminhoArquivo, conteudo);
        Console.WriteLine(" Arquivo criado com sucesso!");
    }


    static void ListarArquivos()
    {
        Console.Write("Digite o nome da pasta: ");
        string pasta = Console.ReadLine();

        if (!Directory.Exists(pasta))
        {
            Console.WriteLine(" A pasta não existe!");
            return;
        }

        string[] arquivos = Directory.GetFiles(pasta);

        if (arquivos.Length == 0)
        {
            Console.WriteLine(" A pasta está vazia!");
        }
        else
        {
            Console.WriteLine(" Arquivos na pasta:");
            foreach (string arquivo in arquivos)
            {
                Console.WriteLine(" " + Path.GetFileName(arquivo));
            }
        }
    }


    static void RenomearArquivo()
    {
        Console.Write("Digite o nome da pasta: ");
        string pasta = Console.ReadLine();

        if (!Directory.Exists(pasta))
        {
            Console.WriteLine(" A pasta não existe!");
            return;
        }

        Console.Write("Digite o nome do arquivo atual: ");
        string nomeAntigo = Console.ReadLine();
        string caminhoAntigo = Path.Combine(pasta, nomeAntigo);

        if (!File.Exists(caminhoAntigo))
        {
            Console.WriteLine(" O arquivo não foi encontrado!");
            return;
        }

        Console.Write("Digite o novo nome do arquivo: ");
        string novoNome = Console.ReadLine();
        string caminhoNovo = Path.Combine(pasta, novoNome);

        File.Move(caminhoAntigo, caminhoNovo);
        Console.WriteLine(" Arquivo renomeado com sucesso!");
    }


    static void DeletarArquivo()
    {
        Console.Write("Digite o nome da pasta: ");
        string pasta = Console.ReadLine();

        if (!Directory.Exists(pasta))
        {
            Console.WriteLine(" A pasta não existe!");
            return;
        }

        Console.Write("Digite o nome do arquivo a ser deletado: ");
        string nomeArquivo = Console.ReadLine();
        string caminho = Path.Combine(pasta, nomeArquivo);

        if (File.Exists(caminho))
        {
            File.Delete(caminho);
            Console.WriteLine(" Arquivo deletado com sucesso!");
        }
        else
        {
            Console.WriteLine(" Arquivo não encontrado!");
        }
    }


    static void DeletarPasta()
    {
        Console.Write("Digite o nome da pasta a ser deletada: ");
        string nomePasta = Console.ReadLine();

        if (Directory.Exists(nomePasta))
        {
            Directory.Delete(nomePasta, true);
            Console.WriteLine(" Pasta deletada com sucesso!");
        }
        else
        {
            Console.WriteLine(" A pasta não existe!");
        }
    }
}
