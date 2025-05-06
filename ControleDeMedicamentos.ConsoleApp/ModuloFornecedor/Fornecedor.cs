using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using System.Text.RegularExpressions;

namespace ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class Fornecedor : EntidadeBase<Fornecedor>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }
        

        public Fornecedor(string nome, string telefone, string cnpj)
        {
            Nome = nome;
            Telefone = telefone;
            CNPJ = cnpj;
        }
        public override void AtualizarRegistro(Fornecedor registroEditado)
        {
            Nome = registroEditado.Nome;
            Telefone = registroEditado.Telefone;
            CNPJ = registroEditado.CNPJ;
        }
        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O campo Nome é obrigatório.\n";

            if (string.IsNullOrWhiteSpace(Telefone))
                erros += "O campo Telefone é obrigatório.\n";

            if (string.IsNullOrWhiteSpace(CNPJ))
                erros += "O campo CNPJ é obrigatório.\n";

            if (Nome.Length < 3)
                erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

            if (Nome.Length > 100)
                erros += "O campo 'Nome' não pode conter mais de 100 caracteres.\n";

            if (CNPJ.Length < 14 || CNPJ.Length > 14)
                erros += "O campo CNPJ não foi devidamente escrito certo.\n";

            if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
                erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.\n";

            return erros.Trim();
        }

    }
}
