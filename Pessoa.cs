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

    public void cadastro()
    {
        System.Console.WriteLine("Digite o nome:");
        this.nome = Console.ReadLine();

        System.Console.WriteLine("Digite a idade:");
        this.idade = int.Parse(Console.ReadLine());
    }

    public string toString()
    {
        return "Nome: " + this.nome + "\nIdade: " + this.idade;
    }

}