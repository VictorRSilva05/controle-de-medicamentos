using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

    public class TelaPaciente : TelaBase<Paciente>, ITelaCrud
    {
        public TelaPaciente(IRepositorioPaciente repositorio) : base("Paciente", repositorio)
        {
        }

        protected override void ExibirCabecalhoTabela()
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", "Id", "Nome", "Telefone", "Cartão SUS");
        }

        protected override void ExibirLinhaTabela(Paciente paciente)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -20} | {3, -20}", paciente.Id, paciente.Nome, paciente.Telefone, paciente.Sus);
        }

        protected override Paciente ObterDados()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite o número do cartão SUS: ");
            string sus = Console.ReadLine() ?? string.Empty;

            Paciente paciente = new Paciente(nome, telefone, sus);
            return paciente;
        }
    
}
