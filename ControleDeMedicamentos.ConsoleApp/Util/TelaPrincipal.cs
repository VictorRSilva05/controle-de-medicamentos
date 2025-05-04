using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeEntrada;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida;
public class TelaPrincipal
{
    public char opcaoPrincipal;

    private TelaFornecedor telaFornecedor;
    private TelaFuncionario telaFuncionario;
    private TelaMedicamento telaMedicamento;
    private TelaRequisicaoDeEntrada telaRequisicaoDeEntrada;
    private TelaPaciente telaPaciente;
    private TelaPrescricao telaPrescricao;
    private TelaRequisicaoDeSaida telaRequisicaoDeSaida;
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

        IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contexto);
        telaPaciente = new TelaPaciente(repositorioPaciente);

        IRepositorioPrescricao repositorioPrescricao = new RepositorioPrescricaoEmArquivo(contexto);
        telaPrescricao = new TelaPrescricao(repositorioPrescricao, repositorioMedicamento);

        IRepositorioRequisicaoDeSaida repositorioRequisicaoDeSaida = new RepositorioRequisicaoDeSaidaEmArquivo(contexto);
        telaRequisicaoDeSaida = new TelaRequisicaoDeSaida(repositorioRequisicaoDeSaida, repositorioPaciente,repositorioPrescricao, repositorioMedicamento);
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
        Console.WriteLine("4 - Cadastro de Pacientes");
        Console.WriteLine("5 - Cadastro de Requisições de saída");
        Console.WriteLine("6 - Cadastro de Requisições de entrada");
        Console.WriteLine("7 - Cadastro de Prescrições médicas");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        EscolherOpcao();
    }

    public ITelaCrud ObterTela()
    {

        if (opcaoPrincipal == '1')
            return telaFornecedor;

        if (opcaoPrincipal == '2')
            return telaFuncionario;

        if (opcaoPrincipal == '3')
            return telaMedicamento;

        if (opcaoPrincipal == '4')
            return telaPaciente;

        if (opcaoPrincipal == '5')
            return telaRequisicaoDeSaida;

        if (opcaoPrincipal == '6')
            return telaRequisicaoDeEntrada;

        if (opcaoPrincipal == '7')
            return telaPrescricao;

        return null;

    }

    private void EscolherOpcao()
    {
        Console.Write("Escolha uma das opções: ");

        opcaoPrincipal = Console.ReadLine()[0];
    }
}