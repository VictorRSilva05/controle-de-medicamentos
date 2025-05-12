using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System.Text;

namespace ControleDeMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            WebApplication app = builder.Build();

            app.MapGet("/", PaginaInicial);

            app.MapGet("/fornecedores/visualizar", VisualizarFornecedores);
            app.MapGet("/fornecedores/cadastrar", ExibirFormularioCadastroFornecedor);
            app.MapPost("/fornecedores/cadastrar", CadastrarFornecedor);
            app.MapGet("/fornecedores/editar/{id:int}", ExibirFormularioEdicaoFornecedor);
            app.MapPost("/fornecedores/editar/{id:int}", EditarFornecedor);
            app.MapGet("/fornecedores/excluir/{id:int}", ExibirFormularioExclusaoFornecedor);
            app.MapPost("/fornecedores/excluir/{id:int}", ExcluirFornecedor);

            app.MapGet("/medicamentos/visualizar", VisualizarMedicamentos);

            app.MapGet("/funcionarios/visualizar", VisualizarFuncionarios);

            app.Run();
        }

        static Task ExcluirFornecedor(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

            repositorioFornecedor.ExcluirRegistro(id);

            string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#mensagem#", $"O registro foi excluido com sucesso");

            string conteudostring = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudostring);
        }

        static Task ExibirFormularioExclusaoFornecedor(HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Fornecedor fabricanteSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);
            string conteudo = File.ReadAllText("ModuloFornecedor/Html/Excluir.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#id#", id.ToString());
            stringBuilder.Replace("#nome#", fabricanteSelecionado.Nome);

            string conteudoString = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudoString);
        }

        static Task EditarFornecedor(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

            string nome = context.Request.Form["nome"].ToString();
            string telefone = context.Request.Form["telefone"].ToString();
            string cnpj = context.Request.Form["CNPJ"].ToString();

            Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

            repositorioFornecedor.EditarRegistro(id, fornecedor);

            string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#mensagem#", $"O registro \"{fornecedor.Nome}\" foi editado com sucesso");

            string conteudostring = stringBuilder.ToString();
            return context.Response.WriteAsync(conteudostring);
        }

        static Task ExibirFormularioEdicaoFornecedor(HttpContext context)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Fornecedor fornecedor = repositorioFornecedor.SelecionarRegistroPorId(id);
            string conteudo = File.ReadAllText("ModuloFornecedor/Html/Editar.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#id#", fornecedor.Id.ToString());
            stringBuilder.Replace("#nome#", fornecedor.Nome);
            stringBuilder.Replace("#telefone#", fornecedor.Telefone);
            stringBuilder.Replace("#cnpj#", fornecedor.CNPJ);

            string conteudostring = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudostring);
        }

        static Task CadastrarFornecedor(HttpContext context)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

            string nome = context.Request.Form["nome"].ToString();
            string telefone = context.Request.Form["telefone"].ToString();
            string cnpj = context.Request.Form["CNPJ"].ToString();

            Fornecedor fornecedor = new Fornecedor(nome,telefone, cnpj);

            repositorioFornecedor.CadastrarRegistro(fornecedor);

            string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#mensagem#", $"O registro \"{fornecedor.Nome}\" foi cadastrado com sucesso");

            string conteudostring = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudostring);
        }

        static Task ExibirFormularioCadastroFornecedor(HttpContext context)
        {
            string conteudo = File.ReadAllText("ModuloFornecedor/Html/Cadastrar.html");
            return context.Response.WriteAsync(conteudo);
        }

        static Task PaginaInicial(HttpContext context)
        {
            string conteudo = File.ReadAllText("Compartilhado/Html/PaginaInicial.html");
            return context.Response.WriteAsync(conteudo);
        }

        static Task VisualizarFornecedores(HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

            string conteudo = File.ReadAllText("ModuloFornecedor/Html/Visualizar.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            List<Fornecedor> fornecedores = repositorioFornecedor.SelecionarRegistros();

            foreach (Fornecedor f in fornecedores)
            {
                string itemLista = $"<li>{f.ToString()} / <a href=\"/fornecedores/editar/{f.Id}\">Editar</a> / <a href=\"/fornecedores/excluir/{f.Id}\">Excluir</a> </li> #fornecedor#";

                stringBuilder.Replace("#fornecedor#", itemLista);
            }

            stringBuilder.Replace("#fornecedor#", "");

            string conteudoString = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudoString);
        }

        static Task VisualizarMedicamentos(HttpContext context)
        {
            string conteudo = File.ReadAllText("ModuloMedicamento/Html/Visualizar.html");
            return context.Response.WriteAsync(conteudo);
        }

        static Task VisualizarFuncionarios(HttpContext context)
        {
            string conteudo = File.ReadAllText("ModuloFuncionario/Html/Visualizar.html");
            return context.Response.WriteAsync(conteudo);
        }
    }
}
