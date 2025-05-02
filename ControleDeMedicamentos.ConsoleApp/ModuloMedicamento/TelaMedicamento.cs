using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase<Medicamento>, ITelaCrud
    {
        public TelaMedicamento(string nomeEntidade, IRepositorio<Medicamento> repositorio) : base(nomeEntidade, repositorio)
        {
        }

        protected override void ExibirCabecalhoTabela()
        {
            throw new NotImplementedException();
        }

        protected override void ExibirLinhaTabela(Medicamento registro)
        {
            throw new NotImplementedException();
        }

        protected override Medicamento ObterDados()
        {
            throw new NotImplementedException();
        }
    }
}
