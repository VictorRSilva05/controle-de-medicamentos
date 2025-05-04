using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamentosPrescritos
{
    public class MedicamentosPrescritos : EntidadeBase<MedicamentosPrescritos>
    {
        public Medicamento Medicamento { get; set; }
        public int Qtd { get; set; }
        public string Dosagem { get; set; }
        public string Periodo { get; set; }

        public MedicamentosPrescritos(Medicamento medicamento, string dosagem, string periodo, int qtd)
        {
            Medicamento = medicamento;
            Dosagem = dosagem;
            Periodo = periodo;
            Qtd = qtd;
        }

        public override void AtualizarRegistro(MedicamentosPrescritos registroEditado)
        {
            throw new NotImplementedException();
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Medicamento.ToString() + " | " + Dosagem + " | " + Periodo + " | " + Qtd;
        }
    }
}
