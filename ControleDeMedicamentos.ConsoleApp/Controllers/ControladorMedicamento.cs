using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Microsoft.AspNetCore.Mvc;

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
}
