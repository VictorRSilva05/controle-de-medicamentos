using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica
{
    public class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
    {
        private IRepositorio<Medicamento> repositorioMedicamento;
        public TelaPrescricao(IRepositorio<Prescricao> repositorio , IRepositorio<Medicamento> repositorioMedicamento) : base("Prescricao", repositorio)
        {
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -20} | {5, -10}", "Id", "Nome"
                 ,"Em falta?");
        }

        protected override void ExibirLinhaTabela(Prescricao prescricao)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {5, -10}", prescricao.Id, prescricao.CRM, prescricao.Data);
        }

        protected Prescricao ObterDados(List<Medicamento> medicamentos)
        {
            Console.Write("Digite o CRM: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite a Data: ");
            string data = Console.ReadLine()!;

            Console.Write("informe o id do Medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine()!);


       

            Medicamento Prescricao = repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

            return Prescricao;
        }
    }
}
