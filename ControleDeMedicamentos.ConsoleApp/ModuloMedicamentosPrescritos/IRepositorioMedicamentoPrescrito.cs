using ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ControleDeMedicamentos.ConsoleApp.ModuloMedicamentosPrescritos
{
    public interface IRepositorioMedicamentoPrescrito : IRepositorio<MedicamentosPrescritos>
    {
        public bool CadastrarRegistro(MedicamentosPrescritos novoRegistro)
        {
            throw new NotImplementedException();
        }

        public bool EditarRegistro(int idRegistro, MedicamentosPrescritos registroEditado)
        {
            throw new NotImplementedException();
        }

        public bool ExcluirRegistro(int idRegistro)
        {
            throw new NotImplementedException();
        }

        public MedicamentosPrescritos SelecionarRegistroPorId(int idRegistro)
        {
            throw new NotImplementedException();
        }

        public List<MedicamentosPrescritos> SelecionarRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
