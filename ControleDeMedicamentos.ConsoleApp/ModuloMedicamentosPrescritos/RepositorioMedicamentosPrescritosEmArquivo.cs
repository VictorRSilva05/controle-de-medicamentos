using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamentosPrescritos
{
    public class RepositorioMedicamentosPrescritosEmArquivo : RepositorioBaseEmArquivo<MedicamentosPrescritos>, IRepositorioMedicamentoPrescrito
    {
        public RepositorioMedicamentosPrescritosEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }
        protected override List<MedicamentosPrescritos> ObterRegistros()
        {
            return contexto.MedicamentosPrescritos;
        }
        protected override bool VerificarRegistroExistente(MedicamentosPrescritos registro)
        {
            return false;
        }
    }


}

