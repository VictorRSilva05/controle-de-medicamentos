using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios
{
    public class RepositorioFuncionarioEmArquivo : RepositorioBaseEmArquivo<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Funcionario> ObterRegistros()
        {
            return contexto.Funcionarios;
        }

        protected override bool VerificarRegistroExistente(Funcionario registro)
        {
            foreach (Funcionario funcionario in ObterRegistros())
            {
                if (funcionario.CPF == registro.CPF)
                {
                    Notificador.ExibirMensagem("CPF já cadastrado!", ConsoleColor.Red);
                    return true;
                }
            }
            return false;
        }
    }
}