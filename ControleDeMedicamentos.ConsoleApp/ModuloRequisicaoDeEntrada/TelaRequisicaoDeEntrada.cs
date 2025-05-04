using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeEntrada
{
    public class TelaRequisicaoDeEntrada : TelaBase<RequisicaoDeEntrada>, ITelaCrud
    {
        private IRepositorio<Funcionario> repositorioFuncionario;
        private IRepositorio<Medicamento> repositorioMedicamento;
        public TelaRequisicaoDeEntrada(IRepositorio<RequisicaoDeEntrada> repositorio, IRepositorio<Funcionario> repositorioFuncionario
            , IRepositorio<Medicamento> repositorioMedicamento) : base("Requisição de entrada", repositorio)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioMedicamento = repositorioMedicamento;
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -10} | {2, -20} | {3, -20} | {4, -20}", "Id", "Data", "Medicamento", "Funcionario", "Quantidade");
        }

        protected override void ExibirLinhaTabela(RequisicaoDeEntrada requisicaoDeEntrada)
        {
            Console.WriteLine("{0, -10} | {1, -10} | {2, -20} | {3, -20} | {4, -20}", requisicaoDeEntrada.Id, requisicaoDeEntrada.Data.ToShortDateString(),
                requisicaoDeEntrada.Medicamento.Nome, requisicaoDeEntrada.Funcionario.Nome, requisicaoDeEntrada.Quantidade);
        }

        protected override RequisicaoDeEntrada ObterDados()
        {
            Console.Write("Insira o id do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine()!);

            Medicamento medicamento = repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

            Console.Write("Insira o id do funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine()!);

            Funcionario funcionario = repositorioFuncionario.SelecionarRegistroPorId(idFuncionario);

            Console.Write("Insira a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine()!);

            medicamento.AdicionarQuantidade(quantidade);
            RequisicaoDeEntrada requisicaoDeEntrada = new RequisicaoDeEntrada(medicamento, funcionario, quantidade);

            return requisicaoDeEntrada;
        }
    }
}
