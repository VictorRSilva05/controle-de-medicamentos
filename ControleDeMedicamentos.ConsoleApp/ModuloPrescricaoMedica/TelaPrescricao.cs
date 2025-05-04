using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentosPrescritos;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica
{
    public class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
    {
        private IRepositorio<Medicamento> repositorioMedicamento;
        public TelaPrescricao(IRepositorio<Prescricao> repositorio , IRepositorio<Medicamento> repositorioMedicamento) : base("Prescricao", repositorio)
        {
            this.repositorioMedicamento = repositorioMedicamento;
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -6} | {1, -7} | {2, -10} | {3, -10}", "Id", "CRM","Data", "Medicamentos");
        }

        protected override void ExibirLinhaTabela(Prescricao prescricao)
        {
            List<MedicamentosPrescritos> auxMedicamentos = prescricao.Medicamentos;
            List<string> medicamentos = new List<string>();

            foreach(MedicamentosPrescritos medicamento in auxMedicamentos)
            {
                string medicamentoFormatado = medicamento.ToString();
                medicamentos.Add(medicamentoFormatado);
            }

            Console.WriteLine("{0, -6} | {1, -7} | {2, -10} | {3, -10}", prescricao.Id, prescricao.CRM, prescricao.Data.ToShortDateString(), medicamentos.ToString());
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

                Console.Write("Informe a quantidade: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                MedicamentosPrescritos medicamentoPrescrito = new MedicamentosPrescritos(medicamento, dosagem, periodo, quantidade);
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
