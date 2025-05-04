using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica
{
    public class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
    {
        private IRepositorio<Medicamento> repositorioMedicamentos;
        public TelaPrescricao(IRepositorio<Prescricao> repositorio, IRepositorio<Medicamento> repositorioMedicamentos) : base("Prescrições médica", repositorio)
        {
            this.repositorioMedicamentos = repositorioMedicamentos;
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -6} | {1, -7} | {2, -10} | {3, -50}", "Id", "CRM", "Data", "Prescrição");
        }

        protected override void ExibirLinhaTabela(Prescricao prescricao)
        {
            string medicamentos = string.Join(", ", prescricao.Medicamentos.Select(m => $"{m.Nome} ({m.Dosagem}, {m.Periodo})"));
            Console.WriteLine("{0, -6} | {1, -7} | {2, -10} | {3, -50}", prescricao.Id, prescricao.CRM, prescricao.Data.ToShortDateString(),
               medicamentos);
        }

        protected override Prescricao ObterDados()
        {
            Console.Write("Informe o CRM: ");
            string cRM = Console.ReadLine();

            List<Medicamento> medicamentos = new List<Medicamento>();

            while (true)
            {
                Console.Write("Informe o Id do medicamento: ");
                int medicamentoId = Convert.ToInt32(Console.ReadLine());

                Medicamento medicamento = repositorioMedicamentos.SelecionarRegistroPorId(medicamentoId);
                if (medicamento == null)
                {
                    Console.WriteLine("Medicamento não disponível. Tente novamente.");
                    continue;
                }

                Console.Write("Informe a dosagem: ");
                string dosagem = Console.ReadLine();

                Console.Write("Informe o período: ");
                string periodo = Console.ReadLine();

                medicamento.ReceitarRemedio(dosagem, periodo);

                medicamentos.Add(medicamento);

                Console.Write("Deseja adicionar mais medicamentos? (s/n): ");
                string opcao = Console.ReadLine();
                if (opcao.ToLower() != "s")
                    break;
            }

            Prescricao prescricao = new Prescricao(cRM, DateTime.Now, medicamentos);
            return prescricao;
        }
    }
}
