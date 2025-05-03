using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
public class TelaPrincipal
{
    public char opcaoPrincipal;  

    private TelaFornecedor telaFornecedor;
    private TelaPaciente telaPaciente;

    public TelaPrincipal()
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
        telaFornecedor = new TelaFornecedor(repositorioFornecedor);

        IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contexto);
        telaPaciente = new TelaPaciente(repositorioPaciente);
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|       Gestão de Medicamentos         |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Fornecedores");
        Console.WriteLine("4 - Cadastro de Pacientes");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        EscolhoerOpcao();
    }

    public ITelaCrud ObterTela()
    {
        
        if (opcaoPrincipal == '1')
            return telaFornecedor;
        if (opcaoPrincipal == '2')
            return telaPaciente;

        return null;
 
    }

    private void EscolhoerOpcao()
    {
        Console.Write("Escolha uma das opções: ");

        opcaoPrincipal = Console.ReadLine()[0];
    }
}