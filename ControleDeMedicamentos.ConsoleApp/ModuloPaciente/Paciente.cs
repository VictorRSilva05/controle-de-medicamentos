using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class Paciente : EntidadeBase<Paciente>
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Sus {  get; set; }

    public Paciente(string nome, string telefone, string sus)
    {
        Nome = nome;
        Telefone = telefone;
        Sus = sus;
    }

    public override void AtualizarRegistro(Paciente novoPaciente)
    {

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

        return erros.Trim();
    }


}
