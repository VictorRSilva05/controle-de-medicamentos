using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Text;

namespace ControleDeMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews(); 

            WebApplication app = builder.Build();

            app.MapGet("/funcionarios/visualizar", VisualizarFuncionarios);
            app.MapGet("/funcionarios/cadastrar", ExibirFormularioCadastroFuncionario);
            app.MapPost("/funcionarios/cadastrar", CadastrarFuncionario);
            app.MapGet("/funcionarios/editar/{id:int}", ExibirFormularioEdicaoFuncionario);
            app.MapPost("funcionarios/editar/{id:int}", EditarFuncionario);
            app.MapGet("/funcionarios/excluir/{id:int}", ExibirFormularioExclusaoFuncionario);
            app.MapPost("/funcionarios/excluir/{id:int}", ExcluirFuncionario);

            app.UseRouting();
            app.MapControllers();
            app.Run();
        }

        static Task ExcluirFuncionario(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);

            repositorioFuncionario.ExcluirRegistro(id);

            string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#mensagem#", $"O registro foi excluido com sucesso");

            string conteudostring = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudostring);
        }

        static Task ExibirFormularioExclusaoFuncionario(HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Funcionario funcionario = repositorioFuncionario.SelecionarRegistroPorId(id);
            string conteudo = File.ReadAllText("ModuloFuncionario/Html/Excluir.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#id#", id.ToString());
            stringBuilder.Replace("#nome#", funcionario.Nome);

            string conteudoString = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudoString);
        }

        static Task EditarFuncionario(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);

            string nome = context.Request.Form["nome"].ToString();
            string telefone = context.Request.Form["telefone"].ToString();
            string cpf = context.Request.Form["CPF"].ToString();

            Funcionario funcionario = new Funcionario(nome, telefone, cpf);

            repositorioFuncionario.EditarRegistro(id, funcionario);

            string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#mensagem#", $"O registro \"{funcionario.Nome}\" foi editado com sucesso");

            string conteudostring = stringBuilder.ToString();
            return context.Response.WriteAsync(conteudostring);
        }

        static Task ExibirFormularioEdicaoFuncionario(HttpContext context)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);

            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Funcionario funcionario = repositorioFuncionario.SelecionarRegistroPorId(id);
            string conteudo = File.ReadAllText("ModuloFuncionario/Html/Editar.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#id#", funcionario.Id.ToString());
            stringBuilder.Replace("#nome#", funcionario.Nome);
            stringBuilder.Replace("#telefone#", funcionario.Telefone);
            stringBuilder.Replace("#cpf#", funcionario.CPF);

            string conteudostring = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudostring);
        }

        static Task CadastrarFuncionario(HttpContext context)
        {
            ContextoDados contexto = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contexto);

            string nome = context.Request.Form["nome"].ToString();
            string telefone = context.Request.Form["telefone"].ToString();
            string cpf = context.Request.Form["CPF"].ToString();

            Funcionario funcionario = new Funcionario(nome, telefone, cpf);

            repositorioFuncionario.CadastrarRegistro(funcionario);

            string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            stringBuilder.Replace("#mensagem#", $"O registro \"{funcionario.Nome}\" foi cadastrado com sucesso");

            string conteudostring = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudostring);
        }

        static Task ExibirFormularioCadastroFuncionario(HttpContext context)
        {
            string conteudo = File.ReadAllText("ModuloFuncionario/Html/Cadastrar.html");
            return context.Response.WriteAsync(conteudo);
        }

        static Task VisualizarFuncionarios(HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            string conteudo = File.ReadAllText("ModuloFuncionario/Html/Visualizar.html");

            StringBuilder stringBuilder = new StringBuilder(conteudo);

            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarRegistros();

            foreach (Funcionario f in funcionarios)
            {
                string itemLista = $"<li>{f.ToString()} / <a href=\"/funcionarios/editar/{f.Id}\">Editar</a> / <a href=\"/funcionarios/excluir/{f.Id}\">Excluir</a> </li> #funcionario#";

                stringBuilder.Replace("#funcionario#", itemLista);
            }

            stringBuilder.Replace("#funcionario#", "");

            string conteudoString = stringBuilder.ToString();

            return context.Response.WriteAsync(conteudoString);
        }
    }
}
