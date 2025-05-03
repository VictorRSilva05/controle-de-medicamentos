using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase<Medicamento>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QtdEmEstoque { get; set; }
        public Fornecedor Fornecedor { get; set; }


        public Medicamento(string nome, string descricao, int qtdEmEstoque, Fornecedor fornecedor)
        {
            Nome = nome;
            Descricao = descricao;
            QtdEmEstoque = qtdEmEstoque;
            Fornecedor = fornecedor;
        }

        public Medicamento()
        {
        }

        public override void AtualizarRegistro(Medicamento registroEditado)
        {
            Nome = registroEditado.Nome;
            Descricao = registroEditado.Descricao;
            QtdEmEstoque = registroEditado.QtdEmEstoque;
            Fornecedor = registroEditado.Fornecedor;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O campo Nome é obrigatório.\n";

            if (string.IsNullOrWhiteSpace(Descricao))
                erros += "O campo Descrição é obrigatório.\n";

            if (QtdEmEstoque < 0)
                erros += "O campo QtdEmEstoque não pode ser menor que 0.\n";

            if(this.Fornecedor == null)
                erros += "O campo Fornecedor é obrigatório.\n";

            return erros.Trim(); 
        }

        internal void AdicionarQuantidade(int quantidade)
        {
            QtdEmEstoque += quantidade;
        }
    }
}
