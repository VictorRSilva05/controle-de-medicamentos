using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("fornecedores")]
public class ControladorFornecedor : Controller
{
    [HttpGet("visualizar")]
    public IActionResult VisualizarFornecedores()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

        string conteudo = System.IO.File.ReadAllText("ModuloFornecedor/Html/Visualizar.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        List<Fornecedor> fornecedores = repositorioFornecedor.SelecionarRegistros();

        foreach (Fornecedor f in fornecedores)
        {
            string itemLista = $"<li>{f.ToString()} / <a href=\"/fornecedores/editar/{f.Id}\">Editar</a> / <a href=\"/fornecedores/excluir/{f.Id}\">Excluir</a> </li> #fornecedor#";

            stringBuilder.Replace("#fornecedor#", itemLista);
        }

        stringBuilder.Replace("#fornecedor#", "");

        string conteudoString = stringBuilder.ToString();

        return Content(conteudoString, "text/html");
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarFornecedor([FromForm]string nome, [FromForm] string telefone, [FromForm] string cnpj)
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

        repositorioFornecedor.CadastrarRegistro(fornecedor);

        string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#mensagem#", $"O registro \"{fornecedor.Nome}\" foi cadastrado com sucesso");

        string conteudostring = stringBuilder.ToString();

        return Content(conteudostring, "text/html");
    }

    [HttpGet("cadastrar")]
    public IActionResult ExibirFormularioCadastroFornecedor()
    {
        string conteudo = System.IO.File.ReadAllText("ModuloFornecedor/Html/Cadastrar.html");
        return Content(conteudo, "text/html");
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult EditarFornecedor([FromRoute] int id, [FromForm] string nome, [FromForm] string telefone, [FromForm] string cnpj)
    { 
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

        repositorioFornecedor.EditarRegistro(id, fornecedor);

        string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#mensagem#", $"O registro \"{fornecedor.Nome}\" foi editado com sucesso");

        string conteudostring = stringBuilder.ToString();
        return Content(conteudostring, "text/html");
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult ExibirFormularioEdicaoFornecedor([FromRoute]int id)
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        Fornecedor fornecedor = repositorioFornecedor.SelecionarRegistroPorId(id);
        string conteudo = System.IO.File.ReadAllText("ModuloFornecedor/Html/Editar.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#id#", fornecedor.Id.ToString());
        stringBuilder.Replace("#nome#", fornecedor.Nome);
        stringBuilder.Replace("#telefone#", fornecedor.Telefone);
        stringBuilder.Replace("#cnpj#", fornecedor.CNPJ);

        string conteudostring = stringBuilder.ToString();

        return Content(conteudostring, "text/html");
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirFornecedor([FromRoute] int id)
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        repositorioFornecedor.ExcluirRegistro(id);

        string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#mensagem#", $"O registro foi excluido com sucesso");

        string conteudostring = stringBuilder.ToString();

        return Content(conteudostring, "text/html");
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult ExibirFormularioExclusaoFornecedor([FromRoute] int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

        Fornecedor fabricanteSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);
        string conteudo = System.IO.File.ReadAllText("ModuloFornecedor/Html/Excluir.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        stringBuilder.Replace("#id#", id.ToString());
        stringBuilder.Replace("#nome#", fabricanteSelecionado.Nome);

        string conteudoString = stringBuilder.ToString();

        return Content(conteudoString, "text/html");
    }

}
