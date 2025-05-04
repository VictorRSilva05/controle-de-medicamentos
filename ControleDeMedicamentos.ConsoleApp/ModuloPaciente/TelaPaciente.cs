using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class TelaPaciente : TelaBase<Paciente>, ITelaCrud
{
    public TelaPaciente(IRepositorioPaciente repositorio) : base("Paciente", repositorio)
    {
    }

    protected override void ExibirCabecalhoTabela()
    {
        Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -10}", "Id", "Nome", "Telefone", "Cartão SUS", "Requisições");
    }

    protected override void ExibirLinhaTabela(Paciente paciente)
    {
        string requisicoes = "";
        if (paciente.Requisicoes.Count <= 0)
        {
            requisicoes = "Nenhuma";
        }
        else
        {
            requisicoes = string.Join(", ", paciente.Requisicoes.Select(r => r.Id));
        }
        Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -10}", paciente.Id, paciente.Nome, paciente.Telefone, paciente.Sus, requisicoes);
    }

    protected override Paciente ObterDados()
    {
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o telefone: ");
        string telefone = Console.ReadLine() ?? string.Empty;

        Console.Write("Digite o número do cartão SUS: ");
        string sus = Console.ReadLine() ?? string.Empty;

        Paciente paciente = new Paciente(nome, telefone, sus);
        return paciente;
    }

}
