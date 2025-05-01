using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
public class TelaPrincipal
{
    public char opcaoPrincipal;  

   private TelaFornecedor telaFornecedor;

    public TelaPrincipal()
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
        telaFornecedor = new TelaFornecedor(repositorioFornecedor);
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|       Gestão de Medicamentos         |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Fornecedores");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        EscolhoerOpcao();
    }

    public ITelaCrud ObterTela()
    {
        
        if (opcaoPrincipal == '1')
            return telaFornecedor;

        return null;
 
    }

    private void EscolhoerOpcao()
    {
        Console.Write("Escolha uma das opções: ");

        opcaoPrincipal = Console.ReadLine()[0];
    }
}