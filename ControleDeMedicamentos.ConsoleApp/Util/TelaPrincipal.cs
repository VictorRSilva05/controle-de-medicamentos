using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
public class TelaPrincipal
{
    public char opcaoPrincipal;

    private TelaFornecedor telaFornecedor;
    private TelaFuncionario telaFuncionario;
    private TelaMedicamento telaMedicamento;

    public TelaPrincipal()
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
        telaFornecedor = new TelaFornecedor(repositorioFornecedor);

        IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);
        telaFuncionario = new TelaFuncionario(repositorioFuncionario);

        IRepositorioMedicamento repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
        telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|       Gestão de Medicamentos         |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Cadastro de Fornecedores");
        Console.WriteLine("2 - Cadastro de Funcionários");
        Console.WriteLine("3 - Cadastro de Medicamentos");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        EscolhoerOpcao();
    }

    public ITelaCrud ObterTela()
    {

        if (opcaoPrincipal == '1')
            return telaFornecedor;

        if (opcaoPrincipal == '2')
            return telaFuncionario;

        if (opcaoPrincipal == '3')
            return telaMedicamento;

        return null;

    }

    private void EscolhoerOpcao()
    {
        Console.Write("Escolha uma das opções: ");

        opcaoPrincipal = Console.ReadLine()[0];
    }
}