using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Numerics;

namespace ControleDeMedicamentos.ConsoleApp.Models;

public abstract class FormularioMedicamentoViewModel
{
    public string Nome { get; set; }
    public int QtdEmEstoque { get; set; }
    public int FornecedorId { get; set; }

    public List<SelecionarFornecedorViewModel> FornecedoresDisponiveis { get; set; }

    public FormularioMedicamentoViewModel()
    {
        FornecedoresDisponiveis = new List<SelecionarFornecedorViewModel>();
    }
}

public class SelecionarFornecedorViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFornecedorViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
public class CadastrarMedicamentoViewModel : FormularioMedicamentoViewModel
{
    public CadastrarMedicamentoViewModel()
    {
    }
    public CadastrarMedicamentoViewModel(List<Fornecedor> fornecedores)
    {
        foreach (var item in fornecedores)
        {
            var selecionarVM = new SelecionarFornecedorViewModel(item.Id, item.Nome);

            FornecedoresDisponiveis.Add(selecionarVM);
        }
    }
}

public class EditarMedicamentoViewModel : FormularioMedicamentoViewModel
{
    public int Id { get; set; }
    public EditarMedicamentoViewModel()
    { 
    }

    public EditarMedicamentoViewModel(int id, string nome,int qtdEmEstoque ,int fornecedorId,List<Fornecedor> fornecedores)
    {
        Id = id;
        Nome = nome;
        QtdEmEstoque = qtdEmEstoque;
        FornecedorId = fornecedorId;

        foreach (var item in fornecedores)
        {
            var selecionarVM = new SelecionarFornecedorViewModel(item.Id, item.Nome);

            FornecedoresDisponiveis.Add(selecionarVM);
        }
    }
}

public class VisualizarMedicamentoViewModel
{
    public List<DetalhesMedicamentoViewModel> Registros { get; set; }

    public VisualizarMedicamentoViewModel(List<Medicamento> medicamentos)
    {
        Registros = new List<DetalhesMedicamentoViewModel>();

        foreach (Medicamento f in medicamentos)
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

    public class ExcluirMedicamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
 
        public ExcluirMedicamentoViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}