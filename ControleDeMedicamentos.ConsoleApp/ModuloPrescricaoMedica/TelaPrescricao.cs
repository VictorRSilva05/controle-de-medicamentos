using ControleDeMedicamentos.ConsoleApp.Compartilhado;
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

        protected override Prescricao ObterDados()
        {
            Console.Write("Informe o CRM: ");
            string cRM = Console.ReadLine();

            DateTime data = DateTime.Now;

            List<MedicamentosPrescritos> medicamentos = new List<MedicamentosPrescritos>();
            while (true)
            {
                Console.Write("Informe o Id do medicamento: ");
                int idMedicamento = Convert.ToInt32(Console.ReadLine());
                Medicamento medicamento = repositorioMedicamento.SelecionarRegistroPorId(idMedicamento);

                Console.Write("Informe a dosagem: ");
                string dosagem = Console.ReadLine();

                Console.Write("Informe o período: ");
                string periodo = Console.ReadLine();

                MedicamentosPrescritos medicamentoPrescrito = new MedicamentosPrescritos(medicamento, dosagem, periodo);
                medicamentos.Add(medicamentoPrescrito);

                Console.Write("Deseja adicionar mais medicamentos? (s/n): ");
                string resposta = Console.ReadLine();
                if (resposta.ToLower() != "s")
                    break;
            }

            Prescricao prescricao = new Prescricao(cRM, data, medicamentos);
            return prescricao;
        }
    }
}
