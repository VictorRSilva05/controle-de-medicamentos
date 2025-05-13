using Microsoft.AspNetCore.Mvc;
namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/")]
public class ControladorInicial : Controller
{
    public IActionResult PaginaInicial()
    {
        return View("PaginaInicial");
    }

}
