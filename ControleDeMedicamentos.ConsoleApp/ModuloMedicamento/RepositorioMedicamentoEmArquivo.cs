using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

public class RepositorioMedicamentoEmArquivo : RepositorioBaseEmArquivo<Medicamento>, IRepositorioMedicamento
{
    public RepositorioMedicamentoEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }
    protected override List<Medicamento> ObterRegistros()
    {
        return contexto.Medicamentos;
    }
    protected override bool VerificarRegistroExistente(Medicamento registro)
    {
        Medicamento medicamentoEncontrado = contexto.Medicamentos.Find(medicamento => medicamento.Nome == registro.Nome)!;

        if (medicamentoEncontrado == null) 
        { 
            return false;
        }

        else
        {
            medicamentoEncontrado.QtdEmEstoque += registro.QtdEmEstoque;
            Notificador.ExibirMensagem("Medicamento encontrado e estoque atualizado!", ConsoleColor.Green);

            return true;
        }

    }
}

