﻿using Microsoft.AspNetCore.Mvc;
namespace ControleDeMedicamentos.ConsoleApp.Controllers;

[Route("/")]
public class ControladorInicial : Controller
{
    public IActionResult PaginaInicial()
    {
        string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/PaginaInicial.html");
        return Content(conteudo, "text/html");
    }

}
