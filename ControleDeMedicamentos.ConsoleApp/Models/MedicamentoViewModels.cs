using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public class VisualizarMedicamentoViewModel
{
    public List<DetalhesMedicamentoViewModel> Registros { get; set; }

    public VisualizarMedicamentoViewModel(List<Medicamento> medicamentos)
    {
        Registros = new List<DetalhesMedicamentoViewModel>();

        foreach(Medicamento f in medicamentos)
        {
            DetalhesMedicamentoViewModel detalhes = f.ParaDetalhesVM();
            Registros.Add(detalhes);
        }
    }
}

public class DetalhesMedicamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int QtdEmEstoque { get; set; }
    public string NomeFornecedor { get; set; }

    public DetalhesMedicamentoViewModel(int id, string nome, int qtdEmEstoque, string nomeFornecedor)
    {
        Id = id;
        Nome = nome;
        QtdEmEstoque = qtdEmEstoque;
        NomeFornecedor = nomeFornecedor;
    }

    public override string ToString()
    {
        return $"Medicamento: {Nome}, Qtd em Estoque: {QtdEmEstoque}, Fornecedor: {NomeFornecedor}";
    }
}