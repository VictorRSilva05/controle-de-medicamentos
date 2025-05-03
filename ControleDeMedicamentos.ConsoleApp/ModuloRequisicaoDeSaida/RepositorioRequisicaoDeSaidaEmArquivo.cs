using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida
{
    public class RepositorioRequisicaoDeSaidaEmArquivo : RepositorioBaseEmArquivo<RequisicaoDeSaida>, IRepositorioRequisicaoDeSaida
    {
        public RepositorioRequisicaoDeSaidaEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }
        protected override List<RequisicaoDeSaida> ObterRegistros()
        {
            return contexto.RequisicoesDeSaida;
        }
    }
}
