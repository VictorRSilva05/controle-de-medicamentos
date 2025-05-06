using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : TelaBase<Fornecedor>, ITelaCrud
    {

        public TelaFornecedor(IRepositorioFornecedor repositorio) : base("Fornecedor", repositorio)
        {
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Nome", "Telefone", "CNPJ");
        }

        protected override void ExibirLinhaTabela(Fornecedor fornecedor)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.CNPJ);
        }

        protected override Fornecedor ObterDados()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine()!;

            Console.Write("Digite o CNPJ: ");
            string cnpj = Console.ReadLine()!;

            Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);
            return fornecedor;
        }

        public override void ExcluirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Excluindo {nomeEntidade}...");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Fornecedor fornecedor = repositorio.SelecionarRegistroPorId(idFabricante);
            if (fornecedor == null)
            {
                Notificador.ExibirMensagem("Fornecedor não encontrado.", ConsoleColor.Red);
                return;
            }

            if (fornecedor.Medicamentos.Count > 0)
            {
                Notificador.ExibirMensagem("Não é possível excluir o fornecedor, pois ele possui medicamentos associados.", ConsoleColor.Red);
                return;
            }
            else
            {

                bool conseguiuExcluir = repositorio.ExcluirRegistro(idFabricante);

                if (!conseguiuExcluir)
                {
                    Notificador.ExibirMensagem("Houve um erro durante a exclusão do registro...", ConsoleColor.Red);

                    return;
                }

                Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
            }
        }

    }
}
