using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica
{
    public class TelaPrescricao : TelaBase<Prescricao>, ITelaCrud
    {
        private IRepositorio<Medicamento> repositorioMedicamentos;
        public TelaPrescricao(IRepositorio<Prescricao> repositorio, IRepositorio<Medicamento> repositorioMedicamentos) : base("Prescrições médica", repositorio)
        {
            this.repositorioMedicamentos = repositorioMedicamentos;
        }

        protected override void ExibirCabecalhoTabela()
        {
            throw new NotImplementedException();
        }

        protected override void ExibirLinhaTabela(Prescricao registro)
        {
            throw new NotImplementedException();
        }

        protected override Prescricao ObterDados()
        {
            throw new NotImplementedException();
        }
    }
}
