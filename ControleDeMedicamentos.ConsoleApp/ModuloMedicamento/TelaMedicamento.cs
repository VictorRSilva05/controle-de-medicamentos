using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase<Medicamento>, ITelaCrud
    {
        private IRepositorio<Fornecedor> repositorioFornecedor;
        public TelaMedicamento(IRepositorio<Medicamento> repositorio, IRepositorio<Fornecedor> repositorioFornecedor) : base("Medicamento", repositorio)
        {
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public void VisualizarRegistroPorId()
        {
            throw new NotImplementedException();
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -30} | {3, -10} | {4, -20} | {5, -10}", "Id", "Nome", "Descrição", 
                "Qtd", "Fornecedor", "Em falta?");
        }

        protected override void ExibirLinhaTabela(Medicamento medicamento)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -30} | {3, -10} | {4, -20} | {5, -10}", medicamento.Id, medicamento.Nome, medicamento.Descricao, medicamento.QtdEmEstoque, medicamento.Fornecedor.Nome, VerificarQuantidadeEmEstoque(medicamento));
        }

        protected override Medicamento ObterDados()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine()!;

            Console.Write("Digite a quantidade em estoque: ");
            int qtdEmEstoque = Convert.ToInt32(Console.ReadLine()!);

            Console.Write("informe o id do fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine()!);

            Fornecedor fornecedor = repositorioFornecedor.SelecionarRegistroPorId(idFornecedor);

            Medicamento medicamento = new Medicamento(nome, descricao, qtdEmEstoque, fornecedor);
            fornecedor.AdicionarMedicamento(medicamento);
            return medicamento;
        }

        private string VerificarQuantidadeEmEstoque(Medicamento medicamento)
        {
            if (medicamento.QtdEmEstoque < 20)
                return "Em falta!";
            else
                return "Disponível!";
        }
    }
}
