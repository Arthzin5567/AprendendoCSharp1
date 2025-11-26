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

                opcao = 0;

                System.Console.WriteLine("Deseja continuar? (s/n)");
                resposta = System.Console.ReadLine().ToLower();
            } else if (opcao == 3)
            {
                System.Console.WriteLine("------------------- EDIÇÃO DE PESSOA -----------------------------------");
                editarPessoa();

                opcao = 0;

                System.Console.WriteLine("Deseja continuar? (s/n)");
                resposta = System.Console.ReadLine().ToLower();
            }
            else if (opcao == 4)
            {
                System.Console.WriteLine("------------------- EXCLUSÃO DE PESSOA ----------------------------------");
                
                excluirPessoa();

                opcao = 0;

                System.Console.WriteLine("Deseja continuar? (s/n)");
                resposta = System.Console.ReadLine().ToLower();
            }

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
}
