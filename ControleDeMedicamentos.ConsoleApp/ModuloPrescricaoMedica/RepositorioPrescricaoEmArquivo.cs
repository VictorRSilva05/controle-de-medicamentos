using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricaoMedica
{
    public class RepositorioPrescricaoEmArquivo : RepositorioBaseEmArquivo<Prescricao>, IRepositorioPrescricao
    {
        public RepositorioPrescricaoEmArquivo (ContextoDados contexto) : base(contexto)
        {

        }
        protected override List<Prescricao> ObterRegistros()
        {
            return contexto.Prescricoes;
        }

        protected override bool VerificarRegistroExistente(Prescricao registro)
        {           
            return false;
        }
    }
}
