using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Microsoft.AspNetCore.Mvc;
using ControleDeMedicamentos.ConsoleApp.Models;
using System.Text;
using ControleDeMedicamentos.ConsoleApp.Extensoes;

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

        VisualizarFornecedoresViewModel visualizarFornecedoresViewModel = new VisualizarFornecedoresViewModel(fornecedores);

        return View("Visualizar", visualizarFornecedoresViewModel);
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarFornecedor(CadastrarFornecedorViewModel fornecedorViewModel)
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        Fornecedor fornecedor = fornecedorViewModel.ParaEntidade();

        repositorioFornecedor.CadastrarRegistro(fornecedor);

        ViewBag.Mensagem =  $"O registro \"{fornecedorViewModel.Nome}\" foi cadastrado com sucesso";

        return View("Notificacao");
    }

    [HttpGet("cadastrar")]
    public IActionResult ExibirFormularioCadastroFornecedor()
    {
        CadastrarFornecedorViewModel cadastrarFornecedorViewModel = new CadastrarFornecedorViewModel();
     
        return View("Cadastrar", cadastrarFornecedorViewModel);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult EditarFornecedor([FromRoute] int id,EditarFornecedorViewModel editarFornecedorVM)
    { 
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        Fornecedor fornecedor = new Fornecedor(editarFornecedorVM.Nome, editarFornecedorVM.Telefone, editarFornecedorVM.CNPJ);

        repositorioFornecedor.EditarRegistro(id, fornecedor);

        ViewBag.Mensagem = $"O registro \"{editarFornecedorVM.Nome}\" foi editado com sucesso";

        return View("Notificacao");
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult ExibirFormularioEdicaoFornecedor([FromRoute]int id)
    {
        ContextoDados contexto = new ContextoDados(true);
        IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contexto);

        Fornecedor fornecedor = repositorioFornecedor.SelecionarRegistroPorId(id);

        EditarFornecedorViewModel fornecedorViewModel = new EditarFornecedorViewModel(
            id, fornecedor.Nome, fornecedor.Telefone, fornecedor.CNPJ);

        return View("Editar", fornecedorViewModel);
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

        ExcluirFornecedorViewModel excluirFornecedorViewModel = new ExcluirFornecedorViewModel(
            fabricanteSelecionado.Id, fabricanteSelecionado.Nome);

        return View("Excluir", excluirFornecedorViewModel);
    }

}
