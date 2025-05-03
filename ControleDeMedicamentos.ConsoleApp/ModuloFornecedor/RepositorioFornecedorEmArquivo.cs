using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedorEmArquivo : RepositorioBaseEmArquivo<Fornecedor>, IRepositorioFornecedor
    {
        public RepositorioFornecedorEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Fornecedor> ObterRegistros()
        {
            return contexto.Fornecedores;
        }

        protected override bool VerificarRegistroExistente(Fornecedor registro)
        {
            foreach (Fornecedor fornecedor in ObterRegistros())
            {
                if (fornecedor.CNPJ == registro.CNPJ)
                {
                    Notificador.ExibirMensagem("CNPJ já cadastrado!", ConsoleColor.Red);
                    return true;
                }
            }
            return false;
        }
    }
}
