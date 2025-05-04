using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida
{
    public class RequisicaoDeSaida : EntidadeBase<RequisicaoDeSaida>
    {
        public DateTime Data { get; set; }
        public Paciente Paciente { get; set; }
        public Prescricao Prescricao { get; set; }
        public List<Medicamento> Medicamentos { get; set; }

        public RequisicaoDeSaida(Paciente paciente, Prescricao prescricao)
        {
            Data = DateTime.Now;
            Paciente = paciente;
            Prescricao = prescricao;
        }

        public RequisicaoDeSaida()
        {
        }

        public override void AtualizarRegistro(RequisicaoDeSaida registroEditado)
        {
            Data = registroEditado.Data;
            Paciente = registroEditado.Paciente;
            Prescricao = registroEditado.Prescricao;
            Medicamentos = registroEditado.Medicamentos;
        }

        public override string Validar()
        {
            string erros = "";

            if (Paciente == null)
                erros += "O campo Paciente é obrigatório.\n";

            if (Prescricao == null)
                erros += "O campo Prescrição é obrigatório.\n";

            if (Medicamentos == null || Medicamentos.Count == 0)
                erros += "O campo Medicamentos é obrigatório.\n";

            return erros;
        }

        public void ObterMedicamentos (List<Medicamento> lista)
        {
            Medicamentos = lista;
        }
    }
}
