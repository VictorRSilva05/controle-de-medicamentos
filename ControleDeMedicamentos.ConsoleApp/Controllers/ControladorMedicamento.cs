using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Microsoft.AspNetCore.Mvc;
using static ControleDeMedicamentos.ConsoleApp.Models.DetalhesMedicamentoViewModel;

namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("medicamentos")]
public class ControladorMedicamento : Controller
{
    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);

        var medicamentos = repositorioMedicamento.SelecionarRegistros();

        VisualizarMedicamentoViewModel visualizarMedicamentoViewModel = new VisualizarMedicamentoViewModel(medicamentos);
        return View(visualizarMedicamentoViewModel);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var contextoDados = new ContextoDados(true);
        var repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

        var fornecedores = repositorioFornecedor.SelecionarRegistros();
        var cadastrarVM = new CadastrarMedicamentoViewModel(fornecedores);
        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarMedicamentoViewModel cadastrarVM)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
        var repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

        var fornecedores = repositorioFornecedor.SelecionarRegistros();

        Medicamento medicamento = cadastrarVM.ParaEntidade(fornecedores);

        var notificacaoVM = new NotificacaoViewModel(
            "Medicamento Cadastrado!",
            $"O registro \"{medicamento.Nome}\" foi cadastrado com sucesso!"
            );

        repositorioMedicamento.CadastrarRegistro(medicamento);
        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id)
    {
        var contextoDados = new ContextoDados(true);
        var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);

        var medicamentoSelecionado = repositorioMedicamento.SelecionarRegistroPorId(id);

        var fornecedores = new RepositorioFornecedorEmArquivo(contextoDados).SelecionarRegistros();

        var editarVM = new EditarMedicamentoViewModel(
            id,
            medicamentoSelecionado.Nome,
            medicamentoSelecionado.QtdEmEstoque,
            medicamentoSelecionado.Fornecedor.Id,
            fornecedores
            );

        return View(editarVM);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id, EditarMedicamentoViewModel editarVM)
    {
        var contextoDados = new ContextoDados(true);
        var fornecedores = new RepositorioFornecedorEmArquivo(contextoDados).SelecionarRegistros();
        var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);

        var medicamentoEditado = editarVM.ParaEntidade(fornecedores);

        repositorioMedicamento.EditarRegistro(id, medicamentoEditado);


        var notificacaoVM = new NotificacaoViewModel(
            "Medicamento Cadastrado!",
            $"O registro \"{medicamentoEditado.Nome}\" foi editado com sucesso!"
            );

        repositorioMedicamento.EditarRegistro(id, medicamentoEditado);
        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        var medicamentoSelecionado = new RepositorioMedicamentoEmArquivo(new ContextoDados(true)).SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirMedicamentoViewModel(id, medicamentoSelecionado.Nome);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirConfirmado([FromRoute] int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
        repositorioMedicamento.ExcluirRegistro(id);

        var notificacaoVM = new NotificacaoViewModel(
            "Medicamento Excluído!",
            $"O registro \"{id}\" foi excluído com sucesso!"
            );

        return View("Notificacao", notificacaoVM);
    }
}
