using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica
{
    public class MedicamentosPrescritos : EntidadeBase<MedicamentosPrescritos>
    {
        public Medicamento Medicamento { get; set; }
        public string Dosagem { get; set; }
        public string Periodo { get; set; }

        public MedicamentosPrescritos(Medicamento medicamento, string dosagem, string periodo)
        {
            Medicamento = medicamento;
            Dosagem = dosagem;
            Periodo = periodo;
        }

        public override void AtualizarRegistro(MedicamentosPrescritos registroEditado)
        {
            throw new NotImplementedException();
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
