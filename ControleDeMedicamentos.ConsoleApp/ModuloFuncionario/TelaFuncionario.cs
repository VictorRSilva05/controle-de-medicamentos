using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios
{
    public class TelaFuncionario : TelaBase<Funcionario>, ITelaCrud
    {
        public TelaFuncionario(IRepositorioFuncionario repositorio) : base("Funcionario", repositorio)
        {
        }

        public void VisualizarRegistroPorId()
        {
            throw new NotImplementedException();
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -6} | {1, -25} | {2, -20} | {3, -20}", "Id", "Nome", "Telefone", "CPF");
        }

        protected override void ExibirLinhaTabela(Funcionario funcionario)
        {
            Console.WriteLine("{0, -6} | {1, -25} | {2, -20} | {3, -20}", funcionario.Id, funcionario.Nome, funcionario.Telefone, funcionario.CPF);
        }

        protected override Funcionario ObterDados()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine()!;

            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine()!;

            Funcionario funcionario = new Funcionario(nome, telefone, cpf);
            return funcionario;
        }

        public override void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Editando {nomeEntidade}...");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idRegistro = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Funcionario registroEditado = ObterDados();

            string erros = registroEditado.Validar();

            if (erros.Length > 0)
            {
                Notificador.ExibirMensagem(erros, ConsoleColor.Red);

                EditarRegistro();

                return;
            }

            foreach (Funcionario funcionario in repositorio.SelecionarRegistros())
            {
                if (funcionario.CPF == registroEditado.CPF)
                {
                    Notificador.ExibirMensagem("Já existe um funcionário cadastrado com esse CPF!", ConsoleColor.Red);
                    return;
                }
            }

            bool conseguiuEditar = repositorio.EditarRegistro(idRegistro, registroEditado);

            if (!conseguiuEditar)
            {
                Notificador.ExibirMensagem("Houve um erro durante a edição do registro...", ConsoleColor.Red);

                return;
            }

            Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
        }
    }
}

