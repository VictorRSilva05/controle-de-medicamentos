using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedorEmMemoria : RepositorioBaseEmArquivo<Fornecedor>
    {
        public RepositorioFornecedorEmMemoria(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Fornecedor> ObterRegistros()
        {
           return contexto.Fornecedores;
        }
    }
}
