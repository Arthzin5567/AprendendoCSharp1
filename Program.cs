using System.Runtime.InteropServices;

public class Program
{
    // Main só acessa aquilo que tá estático
    static List<Pessoa> listaPessoas = new List<Pessoa>();
    public static void Main(string[] args)
    {
        string resposta = "s";
        int opcao = 0;
        Pessoa pessoa = new Pessoa();

        while (resposta == "s")
        {
            System.Console.WriteLine("----------------------------- MENU DE OPÇÕES -----------------------------");
            System.Console.WriteLine("Digite 1 para cadastrar uma nova pessoa.");
            System.Console.WriteLine("Digite 2 para listar todas as pessoas cadastradas.");
            System.Console.WriteLine("Digite 3 para editar uma pessoa cadastrada.");
            System.Console.WriteLine("Digite 4 para excluir uma pessoa cadastrada.");
            System.Console.WriteLine("Digite 5 para gerar arquivo CSV da lista.");
            System.Console.WriteLine("Digite 6 para carregar arquivo CSV da lista no console.");
            System.Console.WriteLine("---------------------------------------------------------------");
            System.Console.WriteLine("Digite n para sair.");

            opcao = System.Convert.ToInt32(Console.ReadLine());
            

            if (opcao == 1)
            {
                System.Console.WriteLine("------------------- CADASTRO DE PESSOA --------------------------------");

                Pessoa novaPessoa = pessoa.cadastro();
                listaPessoas.Add(novaPessoa);
                System.Console.WriteLine("Pessoa cadastrada com sucesso!");

                opcao = 0;

                System.Console.WriteLine("Deseja continuar? (s/n)");
                resposta = System.Console.ReadLine().ToLower();
            }
            else if (opcao == 2) {

                System.Console.WriteLine("------------------- LISTA DE PESSOAS CADASTRADAS -----------------------");

                listarPessoas();

                // Atualiza arquivo CSV após cadastro
                gerarArquivoCSV();

                opcao = 0;

                System.Console.WriteLine("Deseja continuar? (s/n)");
                resposta = System.Console.ReadLine().ToLower();
            } else if (opcao == 3)
            {
                System.Console.WriteLine("------------------- EDIÇÃO DE PESSOA -----------------------------------");

                editarPessoa();

                // Atualiza arquivo CSV após edição
                gerarArquivoCSV();

                opcao = 0;

                System.Console.WriteLine("Deseja continuar? (s/n)");
                resposta = System.Console.ReadLine().ToLower();
            }
            else if (opcao == 4)
            {
                System.Console.WriteLine("------------------- EXCLUSÃO DE PESSOA ----------------------------------");
                
                excluirPessoa();

                // Atualiza arquivo CSV após exclusão
                gerarArquivoCSV();

                opcao = 0;

                System.Console.WriteLine("Deseja continuar? (s/n)");
                resposta = System.Console.ReadLine().ToLower();
            } 
            else if (opcao == 5)
            {
                System.Console.WriteLine("------------------- GERAÇÃO DE ARQUIVO CSV ------------------------------");

                gerarArquivoCSV();

                opcao = 0;

                System.Console.WriteLine("Deseja continuar? (s/n)");
                resposta = System.Console.ReadLine().ToLower();
            } 
            else if (opcao == 6)
            {
                System.Console.WriteLine("------------------- CARREGAMENTO DE ARQUIVO CSV -------------------------");

                verificarPastaData();

                string caminhoArquivo = "data/pessoas.csv";

                if (File.Exists(caminhoArquivo))
                {
                    using (StreamReader sr = new StreamReader(caminhoArquivo))
                    {
                        string linha;
                        bool primeiraLinha = true;

                        while ((linha = sr.ReadLine()) != null)
                        {
                            if (primeiraLinha)
                            {
                                primeiraLinha = false;
                                continue; // Pula o cabeçalho
                            }

                            string[] dados = linha.Split(',');
                            System.Console.WriteLine($"Nome: {dados[0]}, Idade: {dados[1]}");
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Arquivo CSV não encontrado.");
                }

                opcao = 0;

                System.Console.WriteLine("Deseja continuar? (s/n)");
                resposta = System.Console.ReadLine().ToLower();
            } 
             else
            


            if (resposta == "n")
            {
                break;
            } 
            else if (resposta == "s")
            {
                System.Console.WriteLine("Deseja continuar? (s/n)");
            }
            else
            {
                System.Console.WriteLine("Resposta inválida. Por favor, responda com 's' ou 'n'.");
            }
        }

        
    }

    public static void listarPessoas()
    {

        if (listaPessoas.Count == 0)
        {
            System.Console.WriteLine("Nenhuma pessoa cadastrada.");
            return;
        }

        System.Console.WriteLine("Pessoas cadastradas:");

        for (int i = 0; i < listaPessoas.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}. {listaPessoas[i].ToString()}");
        }
    }

    public static void editarPessoa()
    {
        listarPessoas();

        Console.WriteLine("Digite o número da pessoa que deseja editar:");
        int index = int.Parse(Console.ReadLine()) - 1;

        System.Console.WriteLine($"{index+1}. {listaPessoas[index].ToString()}");

        listaPessoas[index].editar();
    }

    public static void excluirPessoa()
    {
        listarPessoas();

        Console.WriteLine("Digite o número da pessoa que deseja excluir:");
        int index = int.Parse(Console.ReadLine()) - 1;

        listaPessoas.RemoveAt(index);

        System.Console.WriteLine("Pessoa excluída com sucesso!");
    }

    public static void verificarPastaData()
    {
        // Cria a pasta "data" se ela não existir
        string pastaData = "data";

        if (!Directory.Exists(pastaData))
        {
            Directory.CreateDirectory(pastaData);
        }
    }

    public static void gerarArquivoCSV()
    {
        verificarPastaData();

        string caminhoArquivo = "data/pessoas.csv";

        using (StreamWriter sw = new StreamWriter(caminhoArquivo))
        {
            sw.WriteLine("Nome,Idade");

            foreach (Pessoa p in listaPessoas)
            {
                sw.WriteLine($"{p.Nome},{p.Idade}");
            }
        }

        System.Console.WriteLine($"Arquivo CSV gerado com sucesso em: {caminhoArquivo}");
    }
}
