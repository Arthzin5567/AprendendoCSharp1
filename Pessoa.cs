public class Pessoa
{
    private string nome = "";
    private int idade = 0;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public int Idade
    {
        get { return idade; }
        set { idade = value; }
    }

    public Pessoa cadastro()
    {
        Pessoa novaPessoa = new Pessoa(); // Cria uma nova instância de Pessoa

        System.Console.WriteLine("Digite o nome:");
        novaPessoa.nome = Console.ReadLine();

        System.Console.WriteLine("Digite a idade:");
        novaPessoa.idade = int.Parse(Console.ReadLine());

        return novaPessoa; // Retorna a nova instância (embora não esteja sendo usada no momento) 
    }

    public Pessoa editar()
    {
        System.Console.WriteLine("Digite o novo nome:");
        this.nome = Console.ReadLine();

        System.Console.WriteLine("Digite a nova idade:");
        this.idade = int.Parse(Console.ReadLine());

        return this; // Retorna a instância atualizada
    }

    public string ToString()
    {
        return "\nNome: " + this.nome + "\nIdade: " + this.idade;
    }

}