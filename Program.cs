public class Program
{
    public static void Main(string[] args)
    {
        Pessoa pessoa = new Pessoa();

        pessoa.cadastro();
        System.Console.WriteLine(pessoa.toString());
        
    }
}
