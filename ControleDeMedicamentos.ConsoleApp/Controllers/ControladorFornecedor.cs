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

        List<Fornecedor> fornecedores = repositorioFornecedor.SelecionarRegistros();

        ViewBag.Fornecedores = fornecedores;

        return View("Visualizar");
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarFornecedor([FromForm]string nome, [FromForm] string telefone, [FromForm] string cnpj)
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

        repositorioFornecedor.CadastrarRegistro(fornecedor);

        ViewBag.Mensagem =  $"O registro \"{fornecedor.Nome}\" foi cadastrado com sucesso";

        return View("Notificacao");
    }

    [HttpGet("cadastrar")]
    public IActionResult ExibirFormularioCadastroFornecedor()
    {
       return View("Cadastrar");
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult EditarFornecedor([FromRoute] int id, [FromForm] string nome, [FromForm] string telefone, [FromForm] string cnpj)
    { 
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

        repositorioFornecedor.EditarRegistro(id, fornecedor);

        ViewBag.Mensagem = $"O registro \"{fornecedor.Nome}\" foi editado com sucesso";

        return View("Notificacao");
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult ExibirFormularioEdicaoFornecedor([FromRoute]int id)
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        Fornecedor fornecedor = repositorioFornecedor.SelecionarRegistroPorId(id);

        ViewBag.Fornecedor = fornecedor;

        return View("Editar");
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirFornecedor([FromRoute] int id)
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        repositorioFornecedor.ExcluirRegistro(id);

         ViewBag.Mensagem = $"O registro foi excluido com sucesso";

        return View("Notificacao");
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult ExibirFormularioExclusaoFornecedor([FromRoute] int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

        Fornecedor fabricanteSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);

        ViewBag.Fornecedor = fabricanteSelecionado;

        return View("Excluir");
    }

}
