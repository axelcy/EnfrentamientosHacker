using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EnfrentamientosHacker.Models;

namespace EnfrentamientosHacker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ListaLuchadores = BD.ListarLuchadores();
        return View();
    }
    public IActionResult IniciarEnfrentamiento()
    {
        return View();
    }
    public Luchador DevolverLuchador(int IdLuchador)
    {
        Luchador luchador = BD.VerInfoLuchador(IdLuchador);
        return luchador;
    }
    public IActionResult ReiniciarJuego()
    {
        BD.ReiniciarJuego();
        return RedirectToAction("Index");
    }
    public IActionResult DuplicarRoster()
    {
        BD.DuplicarRoster();
        return RedirectToAction("Index");
    }
    public IActionResult EliminarLuchador(int IdLuchador)
    {
        BD.EliminarLuchador(IdLuchador);
        return RedirectToAction("Index");
    }
    public IActionResult AgregarLuchador(Luchador luchador)
    {
        BD.AgregarLuchador(luchador);
        return RedirectToAction("Index");
    }
    public IActionResult Registros()
    {
        List<Registro> ListaRegistros = BD.ListarRegistros();

        ViewBag.ListaRegistros = ListaRegistros;
        return View();
    }
    public IActionResult ElimiarListaLuchadores()
    {
        BD.ElimiarListaLuchadores();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
