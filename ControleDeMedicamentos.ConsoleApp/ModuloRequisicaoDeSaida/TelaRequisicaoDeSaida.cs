using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida
{
    public class TelaRequisicaoDeSaida : TelaBase<RequisicaoDeSaida>, ITelaCrud
    {
        private IRepositorio<Paciente> repositorioPaciente;
        private IRepositorio<Prescricao> repositorioPrescricao;
        private IRepositorio<Medicamento> repositorioMedicamentos;
        public TelaRequisicaoDeSaida(IRepositorio<RequisicaoDeSaida> repositorio, IRepositorio<Paciente> repositorioPaciente,
            IRepositorio<Prescricao> repositorioPrescricao, IRepositorio<Medicamento> repositorioMedicamentos) : base("Requisição de saída", repositorio)
        {
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioPrescricao = repositorioPrescricao;
            this.repositorioMedicamentos = repositorioMedicamentos;
        }
        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -6} | {1, -10} | {2, -20} | {3, -10} | {4, -20}", "Id", "Data", "Paciente", "Prescrição", "Medicamentos");
        }
        protected override void ExibirLinhaTabela(RequisicaoDeSaida requisicaoDeSaida)
        {
            string medicamentos = string.Join(", ", requisicaoDeSaida.Medicamentos.Select(m => $"{m.Nome}"));
            Console.WriteLine("{0, -6} | {1, -10} | {2, -20} | {3, -10} | {4, -20}", requisicaoDeSaida.Id,
                requisicaoDeSaida.Data.ToShortDateString(), requisicaoDeSaida.Paciente.Nome, requisicaoDeSaida.Prescricao.Id, medicamentos);
        }
        protected override RequisicaoDeSaida ObterDados()
        {
            Console.Write("Insira o id do paciente: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine())!;

            Paciente paciente = repositorioPaciente.SelecionarRegistroPorId(idPaciente);

            if(paciente == null)
            {
                Console.WriteLine("Paciente não encontrado.");
                return null;
            }

            Console.Write("Insira o id da prescrição: ");
            int idPrescricao = Convert.ToInt32(Console.ReadLine())!;

            Prescricao prescricao = repositorioPrescricao.SelecionarRegistroPorId(idPrescricao);

            if(prescricao == null) {
                Console.WriteLine("Prescrição não encontrada.");
                return null;
            }

            RequisicaoDeSaida requisicaoDeSaida = new RequisicaoDeSaida(paciente,prescricao);
            requisicaoDeSaida.ObterMedicamentos(prescricao.Medicamentos);

            foreach(Medicamento medicamento in requisicaoDeSaida.Medicamentos)
            {
                RemoverMedicamentoDoEstoque(medicamento.Id);
            }

            paciente.AdicionarRequisicao(requisicaoDeSaida);

            return requisicaoDeSaida;
        }

        private bool RemoverMedicamentoDoEstoque(int id)
        {
            Medicamento medicamento = repositorioMedicamentos.SelecionarRegistroPorId(id);
            if (medicamento.QtdEmEstoque < 1)
            {
                Notificador.ExibirMensagem("Sem estoque!", ConsoleColor.Red);
                return false;
            }
            else
            {
                medicamento.QtdEmEstoque -= 1;
                return true;
            }
        }
    }

}
