using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.Extensoes
{
    public static class FornecedorExtensions
    {
        public static Fornecedor ParaEntidade(this FormularioFornecedorViewModel formularioVM)
        {
            return new Fornecedor(formularioVM.Nome, formularioVM.Telefone, formularioVM.CNPJ);
        }

        public static DetalhesFornecedorViewModel ParaDetalhesVM(this Fornecedor fornecedor)
        {
            return new DetalhesFornecedorViewModel(fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.CNPJ);
        }
    }
}
