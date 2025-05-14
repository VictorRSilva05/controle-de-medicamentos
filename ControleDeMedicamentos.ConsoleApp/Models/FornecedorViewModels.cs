using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;

namespace ControleDeMedicamentos.ConsoleApp.Models
{
    public abstract class FormularioFornecedorViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }
    }
    public class VisualizarFornecedoresViewModel
    {
        public List<DetalhesFornecedorViewModel> Fornecedores { get; set; } = new List<DetalhesFornecedorViewModel>();
        public VisualizarFornecedoresViewModel(List<Fornecedor> fornecedores)
        {
            foreach(Fornecedor fornecedor in fornecedores)
            {
                Fornecedores.Add(new DetalhesFornecedorViewModel(fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.CNPJ));
            }
        }
    }

    public class  DetalhesFornecedorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }

        public DetalhesFornecedorViewModel(int id, string nome, string telefone, string cnpj)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Cnpj = cnpj;
        }

        public override string ToString()
        {
            return $"{Nome} - {Telefone} - {Cnpj}";
        }
    }
    public class CadastrarFornecedorViewModel : FormularioFornecedorViewModel
    {


        public CadastrarFornecedorViewModel()
        {
        }

        public CadastrarFornecedorViewModel(string nome, string telefone, string cnpj) : this()
        {
            Nome = nome;
            Telefone = telefone;
            CNPJ = cnpj;
        }

    }
    public class EditarFornecedorViewModel : FormularioFornecedorViewModel
    {
        public int Id { get; set; }

        public EditarFornecedorViewModel()
        {
        }

        public EditarFornecedorViewModel(int id, string nome, string telefone, string cnpj)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CNPJ = cnpj;
        }
    }
    public class ExcluirFornecedorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ExcluirFornecedorViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
