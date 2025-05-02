using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeEntrada;
public class TelaPrincipal
{
    public char opcaoPrincipal;

    private TelaFornecedor telaFornecedor;
    private TelaFuncionario telaFuncionario;
    private TelaMedicamento telaMedicamento;
    private TelaRequisicaoDeEntrada telaRequisicaoDeEntrada;

    public TelaPrincipal()
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);
        telaFornecedor = new TelaFornecedor(repositorioFornecedor);

        IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);
        telaFuncionario = new TelaFuncionario(repositorioFuncionario);

        IRepositorioMedicamento repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contexto);
        telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor);

        IRepositorioRequisicaoDeEntrada repositorioRequisicao = new RepositorioRequisicaoDeEntradaEmArquivo(contexto);
        telaRequisicaoDeEntrada = new TelaRequisicaoDeEntrada(repositorioRequisicao, repositorioFuncionario, repositorioMedicamento);
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
        Console.WriteLine("6 - Cadastro de Requisições de entrada");
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

        if (opcaoPrincipal == '6')
            return telaRequisicaoDeEntrada;

        return null;

    }

    private void EscolhoerOpcao()
    {
        Console.Write("Escolha uma das opções: ");

        opcaoPrincipal = Console.ReadLine()[0];
    }
}