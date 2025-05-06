using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida;
using System.Text.RegularExpressions;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class Paciente : EntidadeBase<Paciente>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Sus {  get; set; }
    public List<RequisicaoDeSaida> Requisicoes { get; set; }

    public Paciente(string nome, string telefone, string sus)
    {
        Nome = nome;
        Telefone = telefone;
        Sus = sus;
        Requisicoes = new List<RequisicaoDeSaida>();
    }

    public Paciente()
    {
    }

    public override void AtualizarRegistro(Paciente novoPaciente)
    {
        Nome = novoPaciente.Nome;
        Telefone = novoPaciente.Telefone;
        Sus = novoPaciente.Sus;
    }
    public override string Validar()
    {
        string erros = " ";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo nome é obrigatório.\n";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo telefone é obrigatório. \n";

        if (string.IsNullOrWhiteSpace(Sus))
            erros += "O campo do cartão do sus é obrigatório. \n";

        if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
            erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.\n";

        if (Sus.Length > 15 || Sus.Length < 15)
            erros += "O campo 'Sus' deve conter 15 caracteres.\n";

        return erros.Trim();
    }

    public void AdicionarRequisicao(RequisicaoDeSaida requisicao)
    {
        Requisicoes.Add(requisicao);
    }

}
