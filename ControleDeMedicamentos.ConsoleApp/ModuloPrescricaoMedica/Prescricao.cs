using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamentosPrescritos;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica
{
    public class Prescricao : EntidadeBase<Prescricao>
    {
        public string CRM { get; set; }
        public DateTime Data { get; set; }
        public List<MedicamentosPrescritos> Medicamentos { get; set; }

        public Prescricao(string cRM, DateTime data, List<MedicamentosPrescritos> medicamentos)
        {
            CRM = cRM;
            Data = data;
            Medicamentos = medicamentos;
        }

        public Prescricao()
        {
        }

        public override void AtualizarRegistro(Prescricao registroEditado)
        {
            CRM = registroEditado.CRM;
            Data = registroEditado.Data;
            Medicamentos = registroEditado.Medicamentos;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(CRM))
                erros += "O campo CRM é obrigatório.\n";

            if (CRM.Length < 6)
                erros += "O campo 'CRM' precisa conter ao menos 6 caracteres.\n";

            if (CRM.Length > 6)
                erros += "O campo 'CRM' não pode conter mais de 6 caracteres.\n";

            if (Medicamentos.Count == 0)
                erros += "É necessário adicionar pelo menos um medicamento.\n";

            return erros.Trim();
        }
    }
}
