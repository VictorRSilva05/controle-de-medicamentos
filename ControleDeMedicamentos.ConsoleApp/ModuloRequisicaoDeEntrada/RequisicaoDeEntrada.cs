using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;

namespace ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeEntrada
{
    public class RequisicaoDeEntrada : EntidadeBase<RequisicaoDeEntrada>
    {
        public DateTime Data { get; set; }
        public Medicamento Medicamento { get; set; }
        public Funcionario Funcionario { get; set; }
        public int Quantidade { get; set; }

        public RequisicaoDeEntrada()
        {
        }

        public RequisicaoDeEntrada(Medicamento medicamento, Funcionario funcionario, int quantidade)
        {
            Data = DateTime.Now;
            Medicamento = medicamento;
            Funcionario = funcionario;
            Quantidade = quantidade;
        }

        public override void AtualizarRegistro(RequisicaoDeEntrada registroEditado)
        {
            Data = registroEditado.Data;
            Medicamento = registroEditado.Medicamento;
            Funcionario = registroEditado.Funcionario;
            Quantidade = registroEditado.Quantidade;
        }

        public override string Validar()
        {
            string erros = "";

            if (Medicamento == null)
                return "O campo Medicamento é obrigatório.";

            if (Funcionario == null)
                return "O campo Funcionario é obrigatório.";

            if (Quantidade <= 0)
                return "O campo Quantidade deve ser maior que zero.";

            return erros.Trim();
        }
    }
}
