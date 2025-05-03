using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

public class RepositorioPacienteEmArquivo : RepositorioBaseEmArquivo<Paciente>, IRepositorioPaciente
{
    public RepositorioPacienteEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Paciente> ObterRegistros()
    {
        return contexto.Pacientes;
    }

    protected override bool VerificarRegistroExistente(Paciente registro)
    {
        foreach (Paciente paciente in ObterRegistros())
        {
            if (paciente.Sus == registro.Sus)
            {
                Notificador.ExibirMensagem("Cartão SUS já cadastrado!", ConsoleColor.Red);
                return true;
            }
        }
        return false;
    }
}
