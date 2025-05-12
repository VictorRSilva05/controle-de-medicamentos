using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using System.Text.RegularExpressions;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;

public class Funcionario : EntidadeBase<Funcionario>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CPF { get; set; }

    public Funcionario(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        CPF = cpf;
    }
    public override void AtualizarRegistro(Funcionario registroEditado)
    {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        CPF = registroEditado.CPF;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo Nome é obrigatório.\n";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo Telefone é obrigatório.\n";

        if (CPF.Length < 11 || CPF.Length > 11)
            erros += "O campo CPF não foi devidamente escrito certo.\n";

        if (string.IsNullOrWhiteSpace(CPF))
            erros += "O campo CPF é obrigatório.\n";

        if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
            erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.\n";

        return erros.Trim();
    }

    public override string ToString()
    {
        return $"{Nome} - {Telefone} - {CPF}";
    }
}
