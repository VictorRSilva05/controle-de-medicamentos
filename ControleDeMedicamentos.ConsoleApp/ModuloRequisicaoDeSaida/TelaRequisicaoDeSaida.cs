using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida
{
    public class TelaRequisicaoDeSaida : TelaBase<RequisicaoDeSaida>, ITelaCrud
    {
        public TelaRequisicaoDeSaida(IRepositorio<RequisicaoDeSaida> repositorio) : base("Requisição de saída", repositorio)
        {
        }
        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -10} | {2, -20} | {3, -20} | {4, -20}", "Id", "Data", "Medicamento", "Funcionario", "Quantidade");
        }
        protected override void ExibirLinhaTabela(RequisicaoDeSaida requisicaoDeSaida)
        {
        //    Console.WriteLine("{0, -10} | {1, -10} | {2, -20} | {3, -20} | {4, -20}", requisicaoDeSaida.Id, requisicaoDeSaida.Data.ToString("dd/MM/yyyy"),
        //        requisicaoDeSaida.Medicamento.Nome, requisicaoDeSaida.Funcionario.Nome, requisicaoDeSaida.Quantidade);
        }
        protected override RequisicaoDeSaida ObterDados()
        {
            throw new NotImplementedException();
        }
    }

}
