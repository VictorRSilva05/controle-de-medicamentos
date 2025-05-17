using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Extensoes
{
    public static class MedicamentoExtensions
    {
        public static DetalhesMedicamentoViewModel ParaDetalhesVM(this Medicamento medicamento)
        {
            return new DetalhesMedicamentoViewModel(medicamento.Id, medicamento.Nome, medicamento.QtdEmEstoque, medicamento.Fornecedor.Nome);
        }
    }
}
