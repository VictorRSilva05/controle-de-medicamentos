using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Extensoes
{
    public static class MedicamentoExtensions
    {
        public static Medicamento ParaEntidade(this FormularioMedicamentoViewModel formularioMedicamentoViewModel, List<Fornecedor> fornecedores)
        {
            Fornecedor fornecedorSelecionado = null;

            foreach(var f in fornecedores)
            {
                if(f.Id == formularioMedicamentoViewModel.FornecedorId)
                {
                    fornecedorSelecionado = f;
                    break;
                }
            }
            return new Medicamento(
                formularioMedicamentoViewModel.Nome,
                formularioMedicamentoViewModel.QtdEmEstoque,
                fornecedorSelecionado
                );
        }
        public static DetalhesMedicamentoViewModel ParaDetalhesVM(this Medicamento medicamento)
        {
            return new DetalhesMedicamentoViewModel(medicamento.Id, medicamento.Nome, medicamento.QtdEmEstoque, medicamento.Fornecedor.Nome);
        }
    }
}
