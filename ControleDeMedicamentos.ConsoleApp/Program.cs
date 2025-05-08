using ControleDeMedicamentos.ConsoleApp.Compartilhado;

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
            app.MapGet("/medicamentos/visualizar", VisualizarMedicamentos);
            app.MapGet("/funcionarios/visualizar", VisualizarFuncionarios);

            app.Run();
        }

        static Task PaginaInicial(HttpContext context)
        {
            string conteudo = File.ReadAllText("Compartilhado/Html/PaginaInicial.html");
            return context.Response.WriteAsync(conteudo);
        }

        static Task VisualizarFornecedores(HttpContext context)
        {
            string conteudo = File.ReadAllText("ModuloFornecedor/Html/Visualizar.html");
            return context.Response.WriteAsync(conteudo);
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
